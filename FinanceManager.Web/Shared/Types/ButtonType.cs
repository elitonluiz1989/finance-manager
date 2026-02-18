namespace FinanceManager.Web.Shared.Types;

public readonly record struct ButtonType
{
    public static ButtonType Button => Parse(ButtonValue);
    public static ButtonType Submit => Parse(BubmitValue);
    public string Value { get; }
    
    private const string ButtonValue = "button";
    private const string BubmitValue = "submit";
    private static string[] ValidValues => [ ButtonValue, BubmitValue ];

    private ButtonType(string value) => Value = HandleValue(value);

    private static ButtonType Parse(string value) => new(value);
    
    public static explicit operator ButtonType(string value) => new(value);
    public static explicit operator string(ButtonType id) => id.ToString();
    
    public override string ToString() => Value;

    private static string HandleValue(string value)
    {
        return ValidValues.Contains(value, StringComparer.InvariantCultureIgnoreCase)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value));
    }
}