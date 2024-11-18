using LambdaWorkbook.Api.Application.Features.UserNoteFeature;
using LambdaWorkbook.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature.Dto;

namespace LambdaWorkbook.Api.Controllers;

public class UserNoteController : ApiControllerBase
{
    private readonly UserNoteService _userNoteService;

    public UserNoteController(
        ILogger<UserNoteController> logger,
        UserNoteService userNoteService) : base(logger)
    {
        _userNoteService = userNoteService;
    }

    [HttpGet("{userId}", Name = "GetUserNotes")]
    public async Task<ActionResult<IEnumerable<UserNoteDto>>> Get(int userId)
    {
        try
        {
            var response = await _userNoteService.GetForUserAsync(userId);

            return response.Failed ?
                BadRequest(response.ErorMessage) :
                Ok(response.Result);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpDelete(Name = "DeleteUserNote")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var response = await _userNoteService.DeleteAsync(id);

            return response.Failed ?
                BadRequest(response.ErorMessage) :
                Ok();
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPut(Name = "UpdateUserNote")]
    public async Task<ActionResult> Update(UserNoteDto dto)
    {
        try
        {
            var response = await _userNoteService.UpdateAsync(dto);

            return response.Failed ?
                BadRequest(response.ErorMessage) :
                Ok();
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPost(Name = "CreateUserNote")]
    public async Task<ActionResult<UserNoteDto>> Create(UserNoteDto dto)
    {
        try
        {
            var response = await _userNoteService.CreateAsync(dto);

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