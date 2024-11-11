using LambdaWorkbook.Api;
using LambdaWorkbook.Api.Application.Features.AuthFeature;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeaure;
using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// DB settings
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

    // Run migrations
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    optionsBuilder.UseNpgsql(connectionString);
    var dbContext = new AppDbContext(optionsBuilder.Options);
    dbContext?.Database.Migrate();
}

// Auth settings
{
    var secret = builder.Configuration["JWT_Secret"];
    var encodedSecret = secret == null ? null : Encoding.UTF8.GetBytes(secret);

    builder.Services.AddSingleton(_ => new JwtConfig
    {
        Secret = secret
    });

    if (encodedSecret != null)
    {
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
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
    builder.Services.AddScoped<IdentityUserService>();
    builder.Services.AddScoped<AuthService>();
}

// Default
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}