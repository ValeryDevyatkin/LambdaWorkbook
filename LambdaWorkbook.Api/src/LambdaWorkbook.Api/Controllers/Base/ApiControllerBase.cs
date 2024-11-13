using LambdaWorkbook.Api.Application.Features.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LambdaWorkbook.Api.Controllers.Base;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ILogger<ApiControllerBase> Logger { get; }

    public ApiControllerBase(ILogger<ApiControllerBase> logger)
    {
        Logger = logger;
    }

    protected ActionResult LogErrorAndReturnResult(Exception ex)
    {
        Logger.LogError(ex, message: ex.Message);

        return BadRequest(OperationResponse.Fail(ex.Message));
    }
}