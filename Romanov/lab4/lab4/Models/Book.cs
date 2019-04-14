﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public ApplicationUser CreatedByApplicationUser { get; set; }

        public ApplicationUser UpdatedByApplicationUser { get; set; }
    }
}