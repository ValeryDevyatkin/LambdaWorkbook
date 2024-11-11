namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;

public class IdentityUserDto
{
    public int? Id { get; set; }
    public string? Login { get; set; }
    public string? RoleName { get; set; }

    public IdentityRoleDto? Role { get; set; }
}