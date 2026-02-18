namespace FinanceManager.Web.Shared.Components.Notification;

public sealed record NotificationItem(string Message)
{
    public string Message { get; private set; } = Message;
    public bool IsVisible { get; set; } = true;

    public static explicit operator NotificationItem(string message) => new(message);
}