using AutoMapper;
using Course.RESTapi.Infrastructure.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.RESTapi.Web.App_Start
{
    public class AutoMapperConfig
    {
            public static void Configure()
            {
                Mapper.Initialize(c => c.AddProfile(typeof(BookMappingProfile)));
            }
    }
}