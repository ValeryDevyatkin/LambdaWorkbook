using LambdaWorkbook.Api.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace LambdaWorkbook.Api.Domain.Model;

public class UserMessage : ModelBase<int>
{
    public string? Text { get; set; }

    [Required]
    public int UserId { get; set; }
    public IdentityUser? User { get; set; }
}