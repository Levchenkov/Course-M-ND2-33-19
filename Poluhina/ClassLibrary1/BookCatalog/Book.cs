﻿using System.Runtime.Serialization;

namespace BookCatalog
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }

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