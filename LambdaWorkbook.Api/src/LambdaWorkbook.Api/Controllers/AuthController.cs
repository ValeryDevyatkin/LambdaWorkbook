using LambdaWorkbook.Api.Application.Features.IdentityUserFeature;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;
using LambdaWorkbook.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IResult> CreateToken([FromServices] JwtConfig jwtConfig, LogInDto logInData)
    {
        if (logInData.Login == null)
        {
            return Results.BadRequest();
        }

        if (!HardCodeLogInHelper.IsAdmin(logInData))
        {
            return Results.Unauthorized();
        }

        var user = await _identityUserService.FindWhenLogInAsync(logInData);
        var jwtToken = jwtConfig.GetToken(logInData.Login);

        return Results.Ok(jwtToken);
    }
}