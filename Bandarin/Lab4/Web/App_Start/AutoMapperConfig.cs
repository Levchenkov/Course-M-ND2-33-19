using AutoMapper;
using Lab4.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(BookMappingProfile)));
        }
    }
}