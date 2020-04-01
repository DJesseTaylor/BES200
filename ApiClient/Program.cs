using CacheCow.Client;
using CacheCow.Client.RedisCacheStore;
using System;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            var client = ClientExtensions.CreateClient(new RedisStore("localhost"));

            client.BaseAddress = new Uri("http://localhost:1337");

            while(true)
            {
                var response = client.GetAsync("/time").Result;
                var data = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(data);
                Console.WriteLine(response.Headers.CacheControl.ToString());
                if (Console.ReadLine() == "done") break;
            }
        }
    }
}
