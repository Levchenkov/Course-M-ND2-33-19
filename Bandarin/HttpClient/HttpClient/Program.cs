using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HttpClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            Book book = new Book() { ID = 19940706, Title = "MyTitle", Author = "bandarin" };
            string bookString = JsonConvert.SerializeObject(book);
            StringContent stringCont = new StringContent(bookString, System.Text.Encoding.UTF8,"application/json");

            var postResult = client.PostAsync("https://eugenetestwebapp.azurewebsites.net/api/books", stringCont).ConfigureAwait(false).GetAwaiter().GetResult();

            var result = client.GetAsync("https://eugenetestwebapp.azurewebsites.net/api/books").ConfigureAwait(false).GetAwaiter().GetResult();
            var stringresult = result.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(stringresult);
            Console.ReadKey();

            var resultBook = client.GetAsync("https://eugenetestwebapp.azurewebsites.net/api/books/19940706").ConfigureAwait(false).GetAwaiter().GetResult();
            var stringresultBook = resultBook.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Book book2 = JsonConvert.DeserializeObject<Book>(stringresultBook);
            book2.Title = "My urgent title";
            var jsonBook = JsonConvert.SerializeObject(book2);

            StringContent stringCont2 = new StringContent(jsonBook, System.Text.Encoding.UTF8, "application/json");
            var putResult = client.PutAsync("https://eugenetestwebapp.azurewebsites.net/api/books/19940706", stringCont2).ConfigureAwait(false).GetAwaiter().GetResult();
            Console.ReadKey();
            var result2 = client.GetAsync("https://eugenetestwebapp.azurewebsites.net/api/books/19940706").ConfigureAwait(false).GetAwaiter().GetResult();
            var stringresult2 = result.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(stringresult2);

            var result3 = client.DeleteAsync("https://eugenetestwebapp.azurewebsites.net/api/books/19940706").ConfigureAwait(false).GetAwaiter().GetResult();
            var result4 = client.GetAsync("https://eugenetestwebapp.azurewebsites.net/api/books").ConfigureAwait(false).GetAwaiter().GetResult();
            var stringresult4 = result4.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(stringresult4);
            Console.ReadKey();

            Console.ReadKey();


        }
    }
}
