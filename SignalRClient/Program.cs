using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Task t = MainAsync(args);
            t.Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/hub")
                .Build();

            await connection.StartAsync();
            
            connection.On<string, string>("ReceiveMessage", (user, message) => {
                Console.WriteLine($"User {user} send the following message {message}");
            });

            Console.WriteLine("Waiting for messages...");
            Console.ReadLine();
        }
    }
}