using LambdaWorkbook.Api.Application.Features.SystemUser;
using LambdaWorkbook.Api.Controllers.Base;

namespace LambdaWorkbook.Api.Controllers;

public class SystemUserController : ApiControllerBase
{
    private readonly SystemUserService _systemUserService;

    public SystemUserController(
        ILogger<SystemUserController> logger,
        SystemUserService systemUserService) : base(logger)
    {
        _systemUserService = systemUserService;
    }
}