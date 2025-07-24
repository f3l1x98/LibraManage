namespace SharedKernel;

public sealed record Error(String code, String? description = null)
{
    public static readonly Error None = new(string.Empty);
    public static readonly Error NullValue = new("Errors.NullValue", "Null value found");
}
