namespace LambdaWorkbook.Api.Domain.Model.Base;

public abstract class ModelBase
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}

public abstract class ModelBase<T> : ModelBase
    where T: struct
{
    public required T Id { get; set; }
}