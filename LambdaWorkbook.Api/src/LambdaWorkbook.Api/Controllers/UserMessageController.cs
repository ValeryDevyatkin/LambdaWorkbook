using LambdaWorkbook.Api.Application.Features.UserMessageFeature;
using LambdaWorkbook.Api.Application.Features.UserMessageFeature.Dto;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature.Dto;
using LambdaWorkbook.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LambdaWorkbook.Api.Controllers;

public class UserMessageController : ApiControllerBase
{
    private readonly UserMessageService _userMessageService;

    public UserMessageController(
        ILogger<ApiControllerBase> logger,
        UserMessageService userMessageService) : base(logger)
    {
        _userMessageService = userMessageService;
    }

    [HttpGet(Name = "GetUserMessages")]
    public async Task<ActionResult<IEnumerable<UserMessageDto>>> Get()
    {
        try
        {
            var response = await _userMessageService.GetAllAsync();

            return response.Failed ?
                BadRequest(response.ErorMessage) :
                Ok(response.Result);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPost(Name = "CreateUserMessage")]
    public async Task<ActionResult<UserNoteDto>> Create(UserMessageDto dto)
    {
        try
        {
            var response = await _userMessageService.CreateAsync(dto);

            return response.Failed ?
                BadRequest(response.ErorMessage) :
                Ok(response.Result);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }
}