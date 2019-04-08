using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Prikhodko.BookCatalogue.Config.MappingProfiles;

namespace Prikhodko.BookCatalogue.PL.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile<BookCatalogueMappingProfile>());
        }
    }
}