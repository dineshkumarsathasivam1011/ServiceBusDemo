using Microsoft.Azure.ServiceBus;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace SBSender.Services
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _configuration;
        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync<T>(T serviceMessage, string queueName)
        {

            var queueClient = new QueueClient(_configuration.GetConnectionString("AzureServiceBus"), queueName);
            string messaageBody = JsonSerializer.Serialize(serviceMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messaageBody));
            // Send across the service bus
            await queueClient.SendAsync(message);
        }
    }
}
