using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Htp.Books.Infrastructure.MappingProfiles;

namespace Htp.Books.Infrastructure
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // https://github.com/AutoMapper/AutoMapper/issues/1109
            // http://www.protomatter.co.uk/blog/development/2017/02/modular-automapper-registrations-with-autofac/
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();

            //builder.Register(context => new MapperConfiguration(cfg =>
            //   cfg.AddProfile(typeof(BookMappingProfile))))
            //.AsSelf()
            //.SingleInstance();

            //builder.Register(c => c.Resolve<MapperConfiguration>()
            //.CreateMapper(c.Resolve))
            //.As<IMapper>()
            //.InstancePerLifetimeScope();

        }
    }
}
