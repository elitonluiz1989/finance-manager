namespace FinanceManager.Web.Shared.Types;

public readonly record struct InputType
{
    public static InputType Password => Parse(PasswordValue);
    public static InputType Text => Parse(TextValue);
    public string Value { get; }
    
    private const string PasswordValue = "password";
    private const string TextValue = "text";
    private static string[] ValidValues => [ PasswordValue, TextValue ];

    private InputType(string value) => Value = HandleValue(value);

    private static InputType Parse(string value) => new(value);
    
    public static explicit operator InputType(string value) => new(value);
    public static explicit operator string(InputType id) => id.ToString();
    
    public override string ToString() => Value;

    private static string HandleValue(string value)
    {
        return ValidValues.Contains(value, StringComparer.InvariantCultureIgnoreCase)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value));
    }
}