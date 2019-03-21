using System.Runtime.Serialization;

namespace Lab2.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Created { get; set; }
        public Genre Genre { get; set; }
        public int[] Languages { get; set; }
        public bool IsDigital { get; set; }
        public object MyProperty { get; set; }
        public int[] FileFormats { get; set; }
    }
}