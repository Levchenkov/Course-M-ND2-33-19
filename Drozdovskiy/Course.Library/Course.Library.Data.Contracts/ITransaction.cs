using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Library.Data.Contracts
{
    public interface ITransaction
    {
        void Commit();
        void RollBack();
    }
}   
