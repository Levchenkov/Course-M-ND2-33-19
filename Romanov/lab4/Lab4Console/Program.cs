using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab4Console
{
    class Program
    {
        class BookApi
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Descrition { get; set; }
        }
        public static async Task GetAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:51113/api/books");
            var str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
        }

        public static async Task GetItemAsync()
        {
            Console.WriteLine("Input ID:");
            var inputId = Convert.ToInt32( Console.ReadLine());
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:51113/api/books/{inputId}");
            var str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
        }
        public static async Task PostAsync()
        {
            var client = new HttpClient();

            Console.WriteLine("Input title:");
            var postBookTitle = Console.ReadLine();
            Console.WriteLine("Input description:");
            var postBookDescription = Console.ReadLine();

            var postBook = new BookApi()
            {
                Title = postBookTitle,
                Descrition = postBookDescription
            };

            var jsonPostBook = JsonConvert.SerializeObject(postBook);
            var strForOut = new StringContent(jsonPostBook, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:51113/api/books", strForOut);
            
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Show all books");
            Console.WriteLine("2. Show book using Id");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await GetAsync();
                    break;
                case "2":
                    await GetItemAsync();
                    break;
            }
            
            Console.ReadLine();
        }
    }
}
