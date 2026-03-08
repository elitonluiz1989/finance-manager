namespace FinanceManager.Web.Shared.Components.Modal;

public readonly record struct ModalSize
{
    public static ModalSize Default { get; } = new(DefaultValue);
    public static ModalSize Small { get; } = new(SmallValue);
    public static ModalSize Large { get; } = new(LargeValue);
    public static ModalSize ExtraLarge { get; } = new(ExtraLargeValue);

    private string Value { get; }

    private const string DefaultValue = "";
    private const string SmallValue = "modal-sm";
    private const string LargeValue = "modal-lg";
    private const string ExtraLargeValue = "modal-xl";

    private ModalSize(string value) => Value = value;
            
    public static explicit operator ModalSize(string value) => new(value);
    public static explicit operator string(ModalSize value) => value.ToString();
            
    public override string ToString() => Value;
}