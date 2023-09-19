using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace MVC_ComponenteCodeFirst.Services.RepoCola
{
    public class Cola
    {
        static string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING")?? "";
        QueueClient queue = new QueueClient(connectionString, "mystoragequeue");

        public async Task InsertMessageAsync(string newMessage)
        {
            if (null != await queue.CreateIfNotExistsAsync())
            {
                Console.WriteLine("The queue was created.");
            }

            await queue.SendMessageAsync(newMessage);
        }
        public async Task<string> RetrieveNextMessageAsync(QueueClient theQueue)
        {
            if (await theQueue.ExistsAsync())
            {
                QueueProperties properties = await theQueue.GetPropertiesAsync();

                if (properties.ApproximateMessagesCount > 0)
                {
                    QueueMessage[] retrievedMessage = await theQueue.ReceiveMessagesAsync(1);
                    string theMessage = retrievedMessage[0].Body.ToString();
                    await theQueue.DeleteMessageAsync(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
                    return theMessage;
                }
                else
                {
                    Console.Write("The queue is empty. Attempt to delete it? (Y/N) ");
                    string response = Console.ReadLine();

                    if (response.ToUpper() == "Y")
                    {
                        await theQueue.DeleteIfExistsAsync();
                        return "The queue was deleted.";
                    }
                    else
                    {
                        return "The queue was not deleted.";
                    }
                }
            }
            else
            {
                return "The queue does not exist. Add a message to the command line to create the queue and store the message.";
            }
        }
    }

}
