namespace LambdaWorkbook.Api.Application.Features.AuthFeature;

public static class HardCodeLogInHelper
{
    public static bool IsAdmin(LogInDto logInData)
    {
        if (logInData.UserName == "admin" && logInData.Password == "minerale")
        {
            return true;
        }

        return false;
    }
}