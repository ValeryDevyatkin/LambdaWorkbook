using LambdaWorkbook.Api.Application.Features.Auth;
using LambdaWorkbook.Api.Application.Features.IdentityUser;
using LambdaWorkbook.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LambdaWorkbook.Api.Controllers;

[Authorize]
public class AuthController : ApiControllerBase
{
    private readonly IdentityUserService _identityUserService;

    public AuthController(
        ILogger<AuthController> logger,
        IdentityUserService identityUserService) : base(logger)
    {
        _identityUserService = identityUserService;
    }

    [AllowAnonymous]
    [HttpPost("create-token")]
    public IResult CreateToken([FromServices] JwtConfig jwtConfig, LogInDto logInData)
    {
        if (logInData.Login == null || jwtConfig.Secret == null)
        {
            return Results.BadRequest();
        }

        if (!HardCodeLogInHelper.IsAdmin(logInData))
        {
            return Results.Unauthorized();
        }

        var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, logInData.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ]),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);

        return Results.Ok(stringToken);
    }
}