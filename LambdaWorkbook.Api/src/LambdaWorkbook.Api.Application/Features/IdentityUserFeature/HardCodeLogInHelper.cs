using LambdaWorkbook.Api.Application.Features.IdentityUserFeature.Dto;

namespace LambdaWorkbook.Api.Application.Features.IdentityUserFeature;

public static class HardCodeLogInHelper
{
    public static bool IsAdmin(LogInDto logInData)
    {
        if (logInData.Login == "admin" && logInData.Password == "minerale")
        {
            return true;
        }

        return false;
    }
}