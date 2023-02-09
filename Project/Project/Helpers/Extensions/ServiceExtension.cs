using Project.Helpers.JwtUtils;
using Project.Repositories;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.ContactInformationRepository;
using Project.Repositories.LeasedRepository;
using Project.Repositories.LocationRepository;
using Project.Repositories.UserRepository;
using Project.Services.ApartmentServices;
using Project.Services.ContactInformationServices;
using Project.Services.LeasedServices;
using Project.Services.LocationServices;
using Project.Services.UserServices;

namespace Project.Helpers.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IContactInformationRepository, ContactInformationRepository>();
            services.AddTransient<ILeasedRepository, LeasedRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IApartmentService, ApartmentService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IContactInformationService, ContactInformationService>();
            services.AddTransient<ILeasedService,LeasedService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();
            
            return services;
        }
    }
}
