namespace LambdaWorkbook.Api.Application.Features.Common;

public class OperationResponse
{
    public object? Result { get; init; }
    public bool Success { get; init; }
    public string? ErorMessage { get; init; }

    public static OperationResponse Failed(string? message)
    {
        return new OperationResponse
        {
            Success = false,
            ErorMessage = message
        };
    }

    public static OperationResponse Succeed(object? result = null)
    {
        return new OperationResponse
        {
            Success = true,
            Result = result
        };
    }
}