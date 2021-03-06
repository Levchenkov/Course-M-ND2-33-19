﻿using System.Runtime.Serialization;

namespace BookLibraryCRUD
{
    /// <summary>
    ///     Book entity,
    ///     serialized for json class
    /// </summary>
    [DataContract]
    public class Book
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Title { get; set; }
    }
}