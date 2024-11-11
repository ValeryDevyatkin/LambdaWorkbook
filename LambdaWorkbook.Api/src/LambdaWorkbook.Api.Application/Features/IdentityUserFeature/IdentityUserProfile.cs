using AutoMapper;
using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeature;

public class IdentityUserProfile : Profile
{
    public IdentityUserProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>()
            .ReverseMap()
            ;
    }
}