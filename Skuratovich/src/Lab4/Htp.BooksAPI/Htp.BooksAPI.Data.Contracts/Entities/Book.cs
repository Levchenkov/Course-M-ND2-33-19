using System;
using System.Threading.Tasks;

namespace Htp.BooksAPI.Data.Contracts.Entities
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        //public virtual string CreatedById { get; set; }
        public  AppUser CreatedBy { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual AppUser UpdatedBy { get; set; }
        public virtual DateTime Updated { get; set; }

        public static implicit operator Task<object>(Book v)
        {
            throw new NotImplementedException();
        }

        //public byte[] RowVersion { get; set; }

        //public long LongRowVersion
        //{
        //    get => BitConverter.ToInt64(RowVersion, 0);
        //    set => RowVersion = BitConverter.GetBytes(value);
        //}
    }
}
