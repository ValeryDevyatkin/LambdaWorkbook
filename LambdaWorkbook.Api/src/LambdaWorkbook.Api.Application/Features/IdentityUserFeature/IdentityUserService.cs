using AutoMapper;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;
using LambdaWorkbook.Api.Application.Repository.Base;

namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeature;

public class IdentityUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public IdentityUserService(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IdentityUserDto> FindWhenLogInAsync(LogInDto logInData)
    {
        var user = await _unitOfWork.IdentityUserRepository
            .FindWhenLogInAsync(logInData.Login, logInData.Password);

        var userDto = _mapper.Map<IdentityUserDto>(user);

        return userDto;
    }
}