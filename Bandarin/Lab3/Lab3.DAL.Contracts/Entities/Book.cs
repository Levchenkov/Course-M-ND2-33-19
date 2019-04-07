
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab3.DAL.Contracts.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string Description { get; set; }
        public string Author { get; set; }
        
        public DateTime Created { get; set; }

        public Genre Genre { get; set; }

        

        public bool IsPaper { get; set; }
        
        public ICollection<Language> Languages { get; set; }
        public int[] Languagess { get; set; }
        

        public DeliveryType Delivery { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public long LongVersion
        {
            get => BitConverter.ToInt64(Version, 0);
            set => Version = BitConverter.GetBytes(value);
        }

    }
}
