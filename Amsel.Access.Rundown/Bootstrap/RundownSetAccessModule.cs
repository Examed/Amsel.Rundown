using Amsel.Access.Rundown.Services;
using Autofac;

namespace Amsel.Access.Rundown.Bootstrap {
    /// <inheritdoc/>
    public class RundownSetAccessModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<RundownSetAccess>();
            builder.RegisterType<RundownSequenceAccess>();
            builder.RegisterType<RundownQueueAccess>();
            builder.RegisterType<RundownElementAccess>();
            builder.RegisterType<RundownFunctionAccess>();
            builder.RegisterType<RundownCompositesAccess>();

            base.Load(builder);
        }
    }
}