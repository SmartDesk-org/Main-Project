using System.Runtime.CompilerServices;

namespace ResourceFlow.WebAPI.DI
{
    public static class InfrastructureServiceRegistration
    {
        public static  IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            return services;
        }
    }
}
