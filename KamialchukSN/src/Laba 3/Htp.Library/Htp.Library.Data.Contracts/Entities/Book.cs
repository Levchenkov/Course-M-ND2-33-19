using System;
using System.ComponentModel.DataAnnotations;

namespace Htp.Library.Data.Contracts.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Genres Genre { get; set; }
        public bool IsPaper { get; set; }
        public Languages Language { get; set; }
        public bool DeliveryRequired { get; set; }


        public enum Genres
        {
            Crime = 1, 
            Detective = 2, 
            Science = 3, 
            Fantasy = 4, 
            Romance = 5, 
            Other = 0
        }

        [Flags]
        public enum Languages
        {
            None = 0,
            Russian = 1,
            English = 2,
            France = 4
        }

        [Timestamp]
        public byte[] Version { get; set; }

        public long LongVersion
        {
            get => BitConverter.ToInt64(Version, 0);
            set => Version = BitConverter.GetBytes(value);
        }
    }
}
