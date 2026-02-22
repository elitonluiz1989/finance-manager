namespace FinanceManager.Web.Shared.Components.Icon;

public record IconType
{
    public static IconType Bars { get; } = new(BarsValue);
        
    private const string BarsValue = "fa-bars";
    private readonly string _value;

    private IconType(string value) => _value = value;
        
    public static explicit operator IconType(string value) => new(value);
    public static explicit operator string(IconType value) => value.ToString();
        
    public override string ToString() => _value;
}