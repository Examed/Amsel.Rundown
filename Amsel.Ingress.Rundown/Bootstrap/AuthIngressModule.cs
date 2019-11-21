using Amsel.Ingress.Authentication.Ingress;
using Autofac;

namespace Amsel.Ingress.Authentication.Bootstrap
{
    /// <inheritdoc />
    public class RundownSetIngressModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RundownSetIngress>();

            base.Load(builder);
        }
    }
}