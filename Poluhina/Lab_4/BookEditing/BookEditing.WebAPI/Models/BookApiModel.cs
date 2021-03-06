﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEditing.WebAPI.Models
{
    public class BookApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}