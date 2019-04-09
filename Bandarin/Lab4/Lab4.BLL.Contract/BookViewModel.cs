using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Contract
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        
        public string CreatedUserName { get; set; }
        
               
        public DateTime IsCreated { get; set; }

        
        public string UpdatedUserName { get; set; }
        public DateTime Updated { get; set; }

        
    }
}
