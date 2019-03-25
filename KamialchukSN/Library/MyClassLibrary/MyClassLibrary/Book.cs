using System.Runtime.Serialization;

namespace MyClassLibrary
{
    [DataContract]
    public class Book
    {
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
