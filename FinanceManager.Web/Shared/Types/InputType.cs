namespace FinanceManager.Web.Shared.Types;

public record InputType
{
    public static InputType Password => new(PasswordValue);
    public static InputType Text => new(TextValue);
    
    private const string PasswordValue = "password";
    private const string TextValue = "text";
    private readonly string _value;

    private InputType(string value) => _value = value;
    
    public static explicit operator string(InputType id) => id.ToString();
    
    public override string ToString() => _value;
}