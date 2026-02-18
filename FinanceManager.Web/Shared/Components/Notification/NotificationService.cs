namespace FinanceManager.Web.Shared.Components.Notification;

public sealed class NotificationService
{
    public event Func<NotificationItem, Task>? OnNotificationAddedAsync;
    
    public event Action? OnNotificationsChanged;
    
    private readonly List<NotificationItem> _notifications = [];
    
    public NotificationItem[] Notifications => _notifications.ToArray();
    public bool HasNotifications => _notifications.Count > 0;
    
    public void Add(string message)
    {
        var notificationItem = new NotificationItem(message);
        
        _notifications.Add(notificationItem);
        
        OnNotificationAddedAsync?.Invoke(notificationItem);
    }

    public void Remove(NotificationItem notification)
    {
        _notifications.Remove(notification);

        OnNotificationsChanged?.Invoke();
    }
}