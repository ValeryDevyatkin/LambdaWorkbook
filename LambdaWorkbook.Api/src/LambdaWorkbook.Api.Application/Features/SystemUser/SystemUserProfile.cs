using AutoMapper;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.SystemUser;

public class SystemUserProfile : Profile
{
    public SystemUserProfile()
    {
        CreateMap<SystemUserModel, SystemUserDto>()
            .ReverseMap()
            ;
    }
}