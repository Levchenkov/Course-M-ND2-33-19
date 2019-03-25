using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Lab2.Entities.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Book : IEntity
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, ErrorMessage = "Title can't be longer than 60 characters")]
        public string Title { get; set; }

        [JsonProperty]
        [MinLength(5)]
        [MaxLength(1024)]
        public string Description { get; set; }

        [JsonProperty]
        public string Author { get; set; }

        [JsonProperty]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [JsonProperty]
        public string Genre { get; set; }

        [JsonProperty]
        [Display(Name = "Available in paper")]
        public bool IsPaper { get; set; }

        [JsonProperty]
        public IEnumerable<LanguageEnum> Languages { get; set; }

        [JsonProperty]
        [Display(Name = "Delivery Required")]
        public bool DeliveryRequired { get; set; }

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Anthology", Text = "Anthology" },
            new SelectListItem { Value = "Crime", Text = "Crime" },
            new SelectListItem { Value = "Fantasy", Text = "Fantasy"  },
            new SelectListItem { Value = "Drama", Text = "Drama"  },
            new SelectListItem { Value = "Horror", Text = "Horror"  },
        };
    }
}