using System.ComponentModel.DataAnnotations;

namespace Lab2.Entities.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, ErrorMessage = "Title can't be longer than 60 characters")]
        public string Title { get; set; }
        //public string Description { get; set; }
        //public string Author { get; set; }
        //public string Created { get; set; }
        //public Genre Genre { get; set; }
        //public int[] Languages { get; set; }
        //public bool IsDigital { get; set; }
        //public object MyProperty { get; set; }
        //public int[] FileFormats { get; set; }
    }
}