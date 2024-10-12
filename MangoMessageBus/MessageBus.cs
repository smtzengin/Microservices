using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace MangoMessageBus
{
    public class MessageBus : IMessageBus
    {
        private string connectingString = "YOUR_CONNECTION_STRING";
        public async Task PublishMessage(object message, string topic_queue_Name)
        {
            await using var client = new ServiceBusClient(connectingString);

            ServiceBusSender sender = client.CreateSender(topic_queue_Name);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalizeMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalizeMessage);
            await client.DisposeAsync();
        }
    }
}
