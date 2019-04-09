using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;

namespace Htp.BooksAPI.Domain.Contracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public string CreatedByUserID { get; set; }

        [Display(Name = "Created by")]
        public string CreatedByUserName { get; set; }

        public DateTime Updated { get; set; }

        public string UpdatedByUserID { get; set; }

        [Display(Name = "Updated by")]
        public string UpdatedByUserName { get; set; }

        //public userID CurrentUser { get; set; }

        //public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
