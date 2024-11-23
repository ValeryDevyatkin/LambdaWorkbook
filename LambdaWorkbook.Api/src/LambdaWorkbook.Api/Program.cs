using LambdaWorkbook.Api;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature;
using LambdaWorkbook.Api.Application.Features.UserMessageFeature;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature;
using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository;
using LambdaWorkbook.Api.Persistence.Repository.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
    var jwtConfig = JwtConfig.CreateFromConfig(builder.Configuration);
    builder.Services.AddSingleton(jwtConfig);

    if (!string.IsNullOrEmpty(jwtConfig.Secret))
    {
        var encodedSecret = Encoding.UTF8.GetBytes(jwtConfig.Secret);

        builder.Services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfig.Issuer,
                ValidAudience = jwtConfig.Audience,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(encodedSecret),
            };
        });
    }
}

// Register services
{
    builder.Services.AddAutoMapper(typeof(IdentityUserProfile));
    builder.Services.AddAutoMapper(typeof(UserNoteProfile));
    builder.Services.AddAutoMapper(typeof(UserMessageProfile));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
    builder.Services.AddScoped<IUserNoteRepository, UserNoteRepository>();
    builder.Services.AddScoped<IUserMessageRepository, UserMessageRepository>();
    builder.Services.AddScoped<IdentityUserService>();
    builder.Services.AddScoped<UserNoteService>();
}

// Default
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lambda Workbook API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter JWT token.",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

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