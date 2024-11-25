using AutoMapper;
using LambdaWorkbook.Api.Application.Features.Common;
using LambdaWorkbook.Api.Application.Features.UserMessageFeature.Dto;
using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.UserMessageFeature;

public class UserMessageService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserMessageService(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResponse<IEnumerable<UserMessageItemDto>>> GetAllAsync()
    {
        var models = await _unitOfWork.UserMessageRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<UserMessageItemDto>>(models);

        return OperationResponse<IEnumerable<UserMessageItemDto>>.Success(dtos);
    }

    public async Task<OperationResponse<UserMessageDto>> CreateAsync(UserMessageDto dto)
    {
        var model = _mapper.Map<UserMessage>(dto);

        var createdModel = await _unitOfWork.UserMessageRepository.CreateAsync(model);
        await _unitOfWork.SaveChangesAsync();

        var createdDto = _mapper.Map<UserMessageDto>(createdModel);

        return OperationResponse<UserMessageDto>.Success(createdDto);
    }
}