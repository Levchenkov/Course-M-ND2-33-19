using System;
using System.Runtime.Serialization;

namespace LibraryEditor.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public string Ganre { get; set; }
        [DataMember]
        public bool IsPaper { get; set; }
        [DataMember]
        public string[] Languages { get; set; }
        [DataMember]
        public bool DeliveryRequired { get; set; }
    }
}