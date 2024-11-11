using AutoMapper;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;
using LambdaWorkbook.Api.Application.Repository;

namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeature;

public class IdentityUserService
{
    private readonly IMapper _mapper;
    private readonly IIdentityUserRepository _identityUserRepository;

    public IdentityUserService(
        IMapper mapper,
        IIdentityUserRepository identityUserRepository)
    {
        _mapper = mapper;
        _identityUserRepository = identityUserRepository;
    }

    public async Task<IdentityUserDto> FindWhenLogInAsync(LogInDto logInData)
    {
        var user = await _identityUserRepository.FindWhenLogInAsync(logInData.Login, logInData.Password);
        var userDto = _mapper.Map<IdentityUserDto>(user);

        return userDto;
    }
}