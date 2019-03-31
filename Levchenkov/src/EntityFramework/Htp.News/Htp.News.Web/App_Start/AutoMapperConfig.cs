using AutoMapper;
using Htp.News.Infrastructure.MappingProfiles;

namespace Htp.News.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(PostMappingProfile)));
        }
    }
}