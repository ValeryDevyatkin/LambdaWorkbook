namespace LambdaWorkbook.Api.Application.Features.UserNoteFeature.Dto;

public class UserNoteDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? Text { get; set; }
}