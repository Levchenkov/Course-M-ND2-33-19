using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Contracts
{
    public interface IRepository<T> where T:class
    {
        
       T Get(int id);
       void Add(T book);
       void Update(T book);
       void Remove(int id);
       void SaveChanges();

        
    }
}
