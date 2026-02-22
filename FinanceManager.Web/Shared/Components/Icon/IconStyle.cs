namespace FinanceManager.Web.Shared.Components.Icon;

public record IconStyle
{
    public static IconStyle Solid { get; } = new(SolidValue);
    public static IconStyle Regular { get; } = new(RegularValue);
    
    private const string SolidValue = "fa-solid";
    private const string RegularValue = "fa-regular";
    private readonly string _value;

    private IconStyle(string value) => _value = value;
    
    public static explicit operator IconStyle(string value) => new(value);
    public static explicit operator string(IconStyle value) => value.ToString();
    
    public override string ToString() => _value;
}