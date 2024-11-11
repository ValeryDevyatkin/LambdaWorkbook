using AutoMapper;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeaure;

public class IdentityUserProfile : Profile
{
    public IdentityUserProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>()
            .ReverseMap()
            ;
    }
}