using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace BookList
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public GenreEnumeration Genre { get; set; }
        [DataMember]
        public bool IsPaper { get; set; }
        [DataMember]
        public LanguagesEnumeration[] Languages { get; set; }
        [DataMember]
        public bool DeliveryRequired { get; set; }
    }
    [DataContract]
    public enum GenreEnumeration
    {
        Classic,
        Business,
        Detective,
        Fantasy,
        Humor,
        Science,
        Directories
    }
    [DataContract]
    public enum LanguagesEnumeration
    {
        Russian = 1,
        English,
        Deutsch
    }
}
