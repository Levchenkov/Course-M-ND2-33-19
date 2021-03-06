﻿using System;
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
            public string Description { get; set; }
            public BookApi()
            {

            }
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

            var postBook = new BookApi();
            postBook.Title = postBookTitle;
            postBook.Description = postBookDescription;

            var jsonPostBook = JsonConvert.SerializeObject(postBook);
            var strForOut = new StringContent(jsonPostBook, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:51113/api/books", strForOut);
            var stringContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(stringContent);
        }

        public static async Task DeleteAsync()
        {
            var client = new HttpClient();
            Console.WriteLine("Input ID:");
            var inputId = Convert.ToInt32(Console.ReadLine());
            var response = await client.DeleteAsync($"http://localhost:51113/api/books/{inputId}");
            var stringContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(stringContent);
        }
        public static async Task PutAsync()
        {
            var client = new HttpClient();
            Console.WriteLine("Input Id");
            var inputId = Convert.ToInt32(Console.ReadLine());
            BookApi bApi = new BookApi();
            Console.WriteLine("Write a new description");
            var newDescription = Console.ReadLine();
            bApi.Description = newDescription;
            var jsonNewDescription = JsonConvert.SerializeObject(bApi);
            var stringContent = new StringContent(jsonNewDescription, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:51113/api/books/{inputId}", stringContent);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. Show book using Id");
                Console.WriteLine("3. Create book");
                Console.WriteLine("4. Delete book");
                Console.WriteLine("5. Edit description");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        await GetAsync();
                        break;
                    case "2":
                        await GetItemAsync();
                        break;
                    case "3":
                        await PostAsync();
                        break;
                    case "4":
                        await DeleteAsync();
                        break;
                    case "5":
                        await PutAsync();
                        break;
                }

                Console.ReadLine();
            }
            
        }
    }
}
