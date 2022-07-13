using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pulse.Application.PipelineBehaviours;
using System.Reflection;

namespace Pulse.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }
    }
}
