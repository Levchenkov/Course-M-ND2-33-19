using AutoMapper;
using Lab.Library.Infrastructure.MappingProfiles;

namespace Lab.Library.Web
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.AllowNullCollections = true;
                c.AddProfile(typeof(BookMappingProfile));
            });
        }
    }
}