using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BookEditing.Models
{
    [DataContract]
    public class Book
    {
        
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public string Genre { get; set; }
        [DataMember]
        public bool IsPaper { get; set; }

        [DataMember]
        public List<string> Languages { get; set; }

        [DataMember]
        public bool DeliveryRequred { get; set; }

    }
}