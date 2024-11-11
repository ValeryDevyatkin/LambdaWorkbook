namespace LambdaWorkbook.Api.Application.Features.Auth;

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