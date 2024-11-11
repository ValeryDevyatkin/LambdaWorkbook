using AutoMapper;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.IdentityUser;

public class IdentityUserProfile : Profile
{
    public IdentityUserProfile()
    {
        CreateMap<IdentityUserModel, IdentityUserDto>()
            .ReverseMap()
            ;
    }
}