using LambdaWorkbook.Api.Application.Features.IdentityUserFeature;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;
using LambdaWorkbook.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LambdaWorkbook.Api.Controllers;

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
    [HttpPost("token")]
    public async Task<IActionResult> GetToken([FromServices] JwtConfig jwtConfig, LogInDto logInData)
    {
        try
        {
            if (logInData.Login == null)
            {
                return BadRequest(nameof(logInData.Login));
            }

            var user = await _identityUserService.FindWhenLogInAsync(logInData);

            if (user == null)
            {
                return NotFound(logInData);
            }

            var jwtToken = jwtConfig.GetToken(logInData.Login);

            return Ok(jwtToken);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }
}