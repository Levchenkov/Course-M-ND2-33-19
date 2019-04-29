using AutoMapper;
using Http.BooksLibrary.Infrastructure.MappingProfiles;

namespace BooksWebApplication
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(PostMappingProfile)));
        }
    }
}