﻿using LambdaWorkbook.Api.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace LambdaWorkbook.Api.Domain.Model;

public class IdentityUser : ModelBase<int>
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Password { get; set; }

    public IdentityRole? Role { get; set; }
}