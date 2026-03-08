namespace FinanceManager.Web.Shared.Components.FormField;

public record FormFieldType
{
    public static FormFieldType Password { get; } = new("password");
    public static FormFieldType Text { get; } = new("text");
    
    private readonly string _value;

    private FormFieldType(string value) => _value = value;
    
    public static explicit operator string(FormFieldType id) => id.ToString();
    
    public override string ToString() => _value;
}