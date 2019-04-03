using Autofac;
using Htp.Books.Common.Contracts;
using Htp.Books.Common.Implementation;

namespace Htp.Books.Infrastructure
{
    public class CommonModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(JsonHistoryLogHandler<>))
                .As(typeof(IHistoryLogHandler<>))
                .InstancePerLifetimeScope();
        }
    }
}