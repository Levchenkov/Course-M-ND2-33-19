using System;
using System.Linq;
using Http.News.Data.EntityFramework;

namespace DataContextCreation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new NewsDbContext();
            var result = context.Categories.ToList();
            foreach (var category in result)
            {
                Console.WriteLine(category.Name);
            }

            Console.ReadLine();
        }
    }
}