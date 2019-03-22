using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibraryEditor.Models
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
        public IEnumerable<EnumGanre> Ganre { get; set; }
        [DataMember]
        public bool IsPaper { get; set; }
        [DataMember]
        public IEnumerable<EnumLanguages> Languages { get; set; }
        [DataMember]
        public bool DeliveryRequired { get; set; }
    }

    public enum EnumGanre
    {
        Crime = 1,
        Detective = 2,
        Science = 4,
        Fantasy = 8,
        Romance = 16,
        Other = 32
    }

    public enum EnumLanguages
    {
        Russian = 1,
        English = 2,
        France = 4
    }
}