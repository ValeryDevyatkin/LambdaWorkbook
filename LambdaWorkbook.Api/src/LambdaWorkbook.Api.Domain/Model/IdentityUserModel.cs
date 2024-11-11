using LambdaWorkbook.Api.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace LambdaWorkbook.Api.Domain.Model;

public class IdentityUserModel : ModelBase<int>
{
    [Required]
    public string? Login { get; set; }

    [Required]
    public string? Password { get; set; }
}