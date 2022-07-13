using Microsoft.Extensions.DependencyInjection;
using Pulse.Application.Common;
using Pulse.Infrastructure.Services;

namespace Pulse.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUserServices, UserServices>();
        }
    }
}
