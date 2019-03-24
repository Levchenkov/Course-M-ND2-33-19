using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebBookLibrary.Models.LibraryModels
{
    /// <summary>
    /// Id - book identifier,
    /// Title - the title,
    /// Description - description,
    /// Author - author,
    /// Created - date of publication (choice of date),
    /// Genre - genre (drop-down list),
    /// Is Paper - is the paper version available (checkbox),
    /// Languages - available languages (multiple choice),
    /// Delivery Required - do you need delivery (radio buttons).
    /// </summary>
    [DataContract]
    public class Book
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Title { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public string Author { get; set; }
        [DataMember] public DateTime Created { get; set; }
        [DataMember] public Genre Genre { get; set; }
        [DataMember] public bool IsPaper { get; set; }
        [DataMember] public List<Language> Languages { get; set; }
        [DataMember] public bool DeliveryRequired { get; set; }
    }
}