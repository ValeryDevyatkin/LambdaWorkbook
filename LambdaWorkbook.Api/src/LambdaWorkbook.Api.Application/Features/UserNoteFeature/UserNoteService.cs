using AutoMapper;
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

    public async Task<IEnumerable<UserNoteDto>> GetForUserAsync(int userId)
    {
        var notes = await _unitOfWork.UserNoteRepository.GetForUserAsync(userId);
        var noteDtoEnumerable = _mapper.Map<IEnumerable<UserNoteDto>>(notes);

        return noteDtoEnumerable;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isSuccess = await _unitOfWork.UserNoteRepository.DeleteAsync(id);

        if (isSuccess)
        {
            await _unitOfWork.SaveChangesAsync();
        }

        return isSuccess;
    }

    public async Task UpdateAsync(UserNoteDto dto)
    {
        var model = _mapper.Map<UserNote>(dto);
        await _unitOfWork.UserNoteRepository.UpdateAsync(model);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<UserNoteDto> CreateAsync(UserNoteDto dto)
    {
        var model = _mapper.Map<UserNote>(dto);
        var createdModel = await _unitOfWork.UserNoteRepository.CreateAsync(model);
        await _unitOfWork.SaveChangesAsync();
        var createdDto = _mapper.Map<UserNoteDto>(createdModel);

        return createdDto;
    }
}