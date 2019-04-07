using System;
using System.Collections.Generic;
using AutoMapper;
using Lab3.Infrasruct.MappingProfiles;
using System.Linq;
using System.Web;

namespace Lab3.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(BookMappigProfile)));
        }
    }
}