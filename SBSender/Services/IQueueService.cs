
namespace SBSender.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T serviceMessage, string queueName);
    }
}