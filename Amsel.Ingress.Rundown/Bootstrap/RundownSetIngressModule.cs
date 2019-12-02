using Amsel.Ingress.Rundown.Ingress;
using Autofac;

namespace Amsel.Ingress.Rundown.Bootstrap
{
    /// <inheritdoc />
    public class RundownSetIngressModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<RundownSetIngress>();

            base.Load(builder);
        }
    }
}