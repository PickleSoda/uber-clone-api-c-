namespace UberClone.Core.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string userId, string message);
    }
}
