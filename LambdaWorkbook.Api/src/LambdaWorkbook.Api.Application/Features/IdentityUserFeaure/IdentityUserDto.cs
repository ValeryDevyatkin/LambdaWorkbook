namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeaure;

public class IdentityUserDto
{
    public int? Id { get; set; }
    public string? UserName { get; set; }
    public string? RoleName { get; set; }

    public IdentityRoleDto? Role { get; set; }
}