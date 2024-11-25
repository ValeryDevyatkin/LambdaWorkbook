using AutoMapper;
using LambdaWorkbook.Api.Application.Features.UserMessageFeature.Dto;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.UserMessageFeature;

public class UserMessageProfile : Profile
{
    public UserMessageProfile()
    {
        CreateMap<UserMessageDto, UserMessage>()
            .ReverseMap()
            ;

        CreateMap<UserMessageItem, UserMessageItemDto>()
            ;
    }
}