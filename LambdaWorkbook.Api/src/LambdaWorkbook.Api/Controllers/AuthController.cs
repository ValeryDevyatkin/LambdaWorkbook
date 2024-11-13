using LambdaWorkbook.Api.Application.Features.Common;
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
    [HttpPost("login")]
    public async Task<ActionResult<OperationResponse<IdentityUserDto>>> LogIn([FromServices] JwtConfig jwtConfig, LogInRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(OperationResponse
                    .Fail($"Empty login [{request.Login}] or password [{request.Password}]."));
            }

            var response = await _identityUserService.FindWhenLogInAsync(request);

            if (response.Failed || response.Result == null)
            {
                return NotFound(response);
            }

            var jwtToken = jwtConfig.GetToken(request.Login);
            response.Result.JwtToken = jwtToken;

            return Ok(response);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [AllowAnonymous]
    [HttpPost("registerpublic")]
    public async Task<ActionResult<OperationResponse<IdentityUserDto>>> RegisterPublicUser(RegisterPublicUserRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(OperationResponse
                    .Fail($"Empty login [{request.Login}] or password [{request.Password}]."));
            }

            var response = await _identityUserService.RegisterPublicUserAsync(request);

            return response.Failed ? BadRequest(response) : Ok(response);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }
}