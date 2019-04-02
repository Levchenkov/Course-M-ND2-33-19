using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookCatalogue;
using BookCataloguePL.Models;

namespace BookEditWebpage
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookViewModel, Book>();
        }
    }
}