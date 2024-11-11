using LambdaWorkbook.Api.Application.Features.SystemUser;
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

    // TODO: Run migrations
    //using (var scope = builder.Services.BuildServiceProvider().CreateScope())
    //{
    //    var dbContext = scope.ServiceProvider.GetRequiredService<MusicManagerDbContext>();
    //    dbContext.Database.Migrate();
    //}
}

// Auth settings
{
    var secret = builder.Configuration["JWT_Secret"];
    var encodedSecret = secret == null ? null : Encoding.UTF8.GetBytes(secret);

    if (encodedSecret != null)
    {
        builder.Services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(encodedSecret),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}

// Register services
{
    builder.Services.AddAutoMapper(typeof(SystemUserProfile));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<ISystemUserRepository, SystemUserRepository>();
    builder.Services.AddScoped<SystemUserService>();
}

// Default
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}