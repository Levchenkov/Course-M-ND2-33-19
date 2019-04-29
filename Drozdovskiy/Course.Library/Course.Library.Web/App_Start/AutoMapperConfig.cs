using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Course.Library.Infrastructure.MappingProfiles;
namespace Course.Library.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c=>c.AddProfile(typeof(BookMappingProfile)));
        }
    }
}