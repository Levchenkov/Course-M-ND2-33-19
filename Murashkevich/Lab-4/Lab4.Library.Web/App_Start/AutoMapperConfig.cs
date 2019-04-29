using AutoMapper;
using Lab4.Library.Infrastructure.MappingProfiles;

namespace Lab4.Library.Web
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.AllowNullCollections = true;
                c.AddProfile(typeof(BookMappingProfiles));
            });
        }
    }
}