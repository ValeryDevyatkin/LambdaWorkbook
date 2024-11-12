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

    public async Task<IdentityUserDto> FindWhenLogInAsync(LogInRequest request)
    {
        var model = await _unitOfWork.IdentityUserRepository
            .FindWhenLogInAsync(request.Login, request.Password);

        var dto = _mapper.Map<IdentityUserDto>(model);

        return dto;
    }

    public async Task<OperationResponse> RegisterPublicUserAsync(RegisterPublicUserRequest request)
    {
        var exists = await _unitOfWork.IdentityUserRepository.FindLoginAsync(request.Login);

        if (exists)
        {
            return OperationResponse.Failed($"Login [{request.Login}] already exists.");
        }

        var model = _mapper.Map<IdentityUser>(request);
        model.RoleId = PublicUserRoleId;

        var createdModel = await _unitOfWork.IdentityUserRepository.CreateAsync(model);
        await _unitOfWork.SaveChangesAsync();

        var createdDto = _mapper.Map<IdentityUserDto>(createdModel);

        return OperationResponse<IdentityUserDto>.Succeed(createdDto);
    }
}