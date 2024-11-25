namespace LambdaWorkbook.Api.Domain.Model;

public class UserMessageItem
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int UserId { get; set; }
    public string? UserLogin { get; set; }
}