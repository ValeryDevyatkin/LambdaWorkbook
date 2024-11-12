using LambdaWorkbook.Api;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature;
using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository;
using LambdaWorkbook.Api.Persistence.Repository.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// DB settings
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?.Trim();

    if (!string.IsNullOrEmpty(connectionString))
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        // Run migrations
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        var dbContext = new AppDbContext(optionsBuilder.Options);
        dbContext?.Database.Migrate();
    }
}

// Auth settings
{
    var secret = builder.Configuration["JWT_Secret"]?.Trim();

    if (!string.IsNullOrEmpty(secret))
    {
        var encodedSecret = secret == null ? null : Encoding.UTF8.GetBytes(secret);

        builder.Services.AddSingleton(_ => new JwtConfig
        {
            Secret = secret
        });

        builder.Services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(encodedSecret),
            };
        });
    }
}

// Register services
{
    builder.Services.AddAutoMapper(typeof(IdentityUserProfile));
    builder.Services.AddAutoMapper(typeof(UserNoteProfile));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
    builder.Services.AddScoped<IUserNoteRepository, UserNoteRepository>();
    builder.Services.AddScoped<IdentityUserService>();
}

// Default
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);



    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // CORS
    app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseHttpsRedirection();
    app.UseCors("AllowSpecificOrigin");
    app.UseAuthentication(); // AuthN
    app.UseAuthorization(); // AuthZ
    app.MapControllers();
    app.Run();
}