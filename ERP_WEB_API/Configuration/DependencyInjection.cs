using ERP_WEB_API.Repositories;

namespace PTLRealERP.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAllRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepositoy>();
            return services;
        }
    }
}
