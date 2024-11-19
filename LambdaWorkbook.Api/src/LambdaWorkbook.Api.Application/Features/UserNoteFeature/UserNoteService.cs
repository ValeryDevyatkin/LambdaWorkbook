using AutoMapper;
using LambdaWorkbook.Api.Application.Features.Common;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature.Dto;
using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.UserNoteFeature;

public class UserNoteService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserNoteService(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResponse<IEnumerable<UserNoteDto>>> GetForUserAsync(int userId)
    {
        var models = await _unitOfWork.UserNoteRepository.GetForUserAsync(userId);
        var dtos = _mapper.Map<IEnumerable<UserNoteDto>>(models);

        return OperationResponse<IEnumerable<UserNoteDto>>.Success(dtos);
    }

    public async Task<OperationResponse> DeleteAsync(int id)
    {
        var success = await _unitOfWork.UserNoteRepository.DeleteAsync(id);

        if (success)
        {
            await _unitOfWork.SaveChangesAsync();
        }

        return success ?
            OperationResponse.Success() :
            OperationResponse.Fail($"Заметка с номером [{id}] не найдена.");
    }

    public async Task<OperationResponse> UpdateAsync(UserNoteDto dto)
    {
        var model = _mapper.Map<UserNote>(dto);

        await _unitOfWork.UserNoteRepository.UpdateAsync(model);
        await _unitOfWork.SaveChangesAsync();

        return OperationResponse.Success();
    }

    public async Task<OperationResponse<UserNoteDto>> CreateAsync(UserNoteDto dto)
    {
        var model = _mapper.Map<UserNote>(dto);

        var createdModel = await _unitOfWork.UserNoteRepository.CreateAsync(model);
        await _unitOfWork.SaveChangesAsync();

        var createdDto = _mapper.Map<UserNoteDto>(createdModel);

        return OperationResponse<UserNoteDto>.Success(createdDto);
    }
}