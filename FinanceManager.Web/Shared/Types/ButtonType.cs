namespace FinanceManager.Web.Shared.Types;

public record ButtonType
{
    public static ButtonType Button => new(ButtonValue);
    public static ButtonType Submit => new(BubmitValue);
    
    private const string ButtonValue = "button";
    private const string BubmitValue = "submit";
    private readonly string _value;

    private ButtonType(string value) => _value = value;
    
    public static explicit operator string(ButtonType value) => value.ToString();
    
    public override string ToString() => _value;
}