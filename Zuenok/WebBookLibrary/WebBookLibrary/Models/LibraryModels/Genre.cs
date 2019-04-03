using System;

namespace WebBookLibrary.Models.LibraryModels
{
    [Flags]
    public enum Genre
    {
        Crime = 2,
        Detective = 4,
        Science = 8,
        Fantasy = 16,
        Romance = 32,
        Other = 64
    }
}