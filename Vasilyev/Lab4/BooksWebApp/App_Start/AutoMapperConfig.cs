using AutoMapper;
using Http.BooksLibrary.Infrastructure.MappingProfiles;

namespace BooksWebApp
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(PostMappingProfile)));
        }
    }
}