using AutoMapper;
using LambdaWorkbook.Api.Application.Features.UserNoteFeature.Dto;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Features.UserNoteFeature;

public class UserNoteProfile : Profile
{
    public UserNoteProfile()
    {
        CreateMap<UserNote, UserNoteDto>()
            .ReverseMap()
            ;
    }
}