

namespace BookCatalogue
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearOfIssue { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}; Name: \"{Name}\"; by {Author} ({YearOfIssue})";
        }
    }
}
