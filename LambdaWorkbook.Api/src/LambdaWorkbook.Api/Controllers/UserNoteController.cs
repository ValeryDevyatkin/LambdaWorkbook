﻿using LambdaWorkbook.Api.Application.Features.UserNoteFeature;
using LambdaWorkbook.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature.Dto;
using LambdaWorkbook.Api.Application.Features.Common;

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
    public async Task<ActionResult<OperationResponse<IEnumerable<UserNoteDto>>>> Get(int userId)
    {
        try
        {
            var notes = await _userNoteService.GetForUserAsync(userId);

            return Ok(OperationResponse<IEnumerable<UserNoteDto>>.Succeed(notes));
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<OperationResponse>> Delete(int id)
    {
        try
        {
            var isSucess = await _userNoteService.DeleteAsync(id);

            if (isSucess)
            {
                return Ok(OperationResponse.Succeed());
            }

            return NotFound(OperationResponse.Failed($"Item with id [{id}] was not found."));
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPut]
    public async Task<ActionResult<OperationResponse>> Update(UserNoteDto dto)
    {
        try
        {
            await _userNoteService.UpdateAsync(dto);

            return Ok(OperationResponse.Succeed());
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult<OperationResponse<UserNoteDto>>> Create(UserNoteDto dto)
    {
        try
        {
            var result = await _userNoteService.CreateAsync(dto);

            return Ok(OperationResponse<UserNoteDto>.Succeed(result));
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }
}