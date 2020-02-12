using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.News.Data.EntityFramework
{
    public class HistoryLog
    {
        public int Id { get; set; }

        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string OriginalValue { get; set; }
        public string ActualValue { get; set; }
    }
}
