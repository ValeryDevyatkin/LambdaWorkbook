using AutoMapper;
using LambdaWorkbook.Api.Application.Features.Common;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;
using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeature;

public class IdentityUserService
{
    private const int PublicUserRoleId = 1;

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public IdentityUserService(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResponse<IdentityUserDto>> FindWhenLogInAsync(LogInRequest request)
    {
        var model = await _unitOfWork.IdentityUserRepository
            .FindWhenLogInAsync(request.Login, request.Password);

        if (model == null)
        {
            return OperationResponse<IdentityUserDto>
                .Fail($"Пользователь [{request.Login}] не найден.");
        }

        var dto = _mapper.Map<IdentityUserDto>(model);

        return OperationResponse<IdentityUserDto>.Success(dto);
    }

    public async Task<OperationResponse<IdentityUserDto>> RegisterPublicUserAsync(RegisterPublicUserRequest request)
    {
        var exists = await _unitOfWork.IdentityUserRepository.FindLoginAsync(request.Login);

        if (exists)
        {
            return OperationResponse<IdentityUserDto>
                .Fail($"Пользователь [{request.Login}] уже существует.");
        }

        var model = _mapper.Map<IdentityUser>(request);
        model.RoleId = PublicUserRoleId;

        var createdModel = await _unitOfWork.IdentityUserRepository.CreateAsync(model);
        await _unitOfWork.SaveChangesAsync();

        var createdDto = _mapper.Map<IdentityUserDto>(createdModel);

        return OperationResponse<IdentityUserDto>.Success(createdDto);
    }
}