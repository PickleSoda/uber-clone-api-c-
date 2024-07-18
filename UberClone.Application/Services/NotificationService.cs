using System.Threading.Tasks;
using UberClone.Application.Interfaces;
using UberClone.Core.Entities;
using UberClone.Core.Interfaces;

public class NotificationService : INotificationService
{
    public Task SendNotificationAsync(string userId, string message)
    {
        Console.WriteLine($"Notification sent: {message}");
        return Task.CompletedTask;
    }
}
