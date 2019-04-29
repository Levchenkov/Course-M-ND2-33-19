using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Contracts.Entities
{
    public enum TypesofDelivery { Required, NotRequired}
    public class DeliveryType
    {
        public int Id { get; set; }
        public TypesofDelivery Type { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
