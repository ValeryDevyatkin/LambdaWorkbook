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

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<UserNoteDto>>> Get(int userId)
    {
        try
        {
            var notes = await _userNoteService.GetForUserAsync(userId);

            return Ok(notes);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var isSucess = await _userNoteService.DeleteAsync(id);

            if (isSucess)
            {
                return Ok(id);
            }

            return NotFound(id);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(UserNoteDto dto)
    {
        try
        {
            await _userNoteService.UpdateAsync(dto);

            return Ok();
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserNoteDto>> Create(UserNoteDto dto)
    {
        try
        {
            var result = await _userNoteService.CreateAsync(dto);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }
}