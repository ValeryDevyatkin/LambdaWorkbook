using LambdaWorkbook.Api.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace LambdaWorkbook.Api.Domain.Model;

public class IdentityRole : ModelBase<int>
{
    [Required]
    public string? Name { get; set; }
}