namespace BookCatalog
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Genre { get; set; }
    }
}
