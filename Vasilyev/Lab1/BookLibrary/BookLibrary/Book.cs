using System.Runtime.Serialization;

namespace BookLibrary
{
    [DataContract]
    public class Book
    {
        public Book()
        {

        }

        public Book(int id, string title)
        {
            Id = id;
            Title = title;
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }
    }
}