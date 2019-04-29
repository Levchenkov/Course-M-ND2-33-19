using AutoMapper;
using Htp.Library.Infrastructure.MappingProfiles;

namespace Htp.Library.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(BookMappingProfile)));
        }
    }
}