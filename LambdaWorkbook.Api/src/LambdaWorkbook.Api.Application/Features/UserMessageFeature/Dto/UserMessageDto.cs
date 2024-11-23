namespace LambdaWorkbook.Api.Application.Features.UserMessageFeature.Dto;

public class UserMessageDto
{
    public int? Id { get; set; }
    public string? Text { get; set; }
    public int UserId { get; set; }
    public string? UserLogin { get; set; }
}