using Microsoft.AspNetCore.Mvc;

namespace LambdaWorkbook.Api.Controllers.Base;

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
        Logger.LogError(ex, ex.Message);

        return BadRequest(ex.Message);
    }
}