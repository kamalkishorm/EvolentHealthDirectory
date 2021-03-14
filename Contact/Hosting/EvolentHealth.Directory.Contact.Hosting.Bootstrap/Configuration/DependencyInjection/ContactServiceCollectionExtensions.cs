using EvolentHealth.Directory.Contact.Business;
using EvolentHealth.Directory.Contact.Contract.Configurations;
using EvolentHealth.Directory.Contact.Contract.Interface.Business;
using EvolentHealth.Directory.Contact.Contract.Interface.DataAccess;
using EvolentHealth.Directory.Contact.Contract.Interface.Repository;
using EvolentHealth.Directory.Contact.DataAccess;
using EvolentHealth.Directory.Contact.Repository;
using EvolentHealth.Directory.Contact.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EvolentHealth.Directory.Contact.Hosting.Bootstrap.Configuration.DependencyInjection
{
    public static class ContactServiceCollectionExtensions 
    {
        public static IServiceCollection AddContactServices(this IServiceCollection services,
            ContactConfiguration contactConfiguration, bool isDevelopment)
        {
            AddContactDatabase(services, contactConfiguration, isDevelopment);
            AddBusinessService(services);
            AddDataAccessService(services);
            AddRepositoryService(services);
            return services;
        }

        /// <summary>
        /// Configure DB Context
        /// </summary>
        private static void AddContactDatabase(IServiceCollection services, ContactConfiguration contactConfiguration,
            bool isDevelopment)
        {
            services.AddDbContext<EvolentHealthDirectoryContext>(options =>
            {
                options.UseSqlServer(contactConfiguration.ConnectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(isDevelopment);
            });
        }

        /// <summary>
        /// Configure Business services
        /// </summary>
        private static void AddBusinessService(IServiceCollection services)
        {
            services.AddTransient<IContacts, Contacts>();
        }

        /// <summary>
        /// Configure Data Access services
        /// </summary>
        private static void AddDataAccessService(IServiceCollection services)
        {
            services.AddTransient<IContactDataAccess, ContactDataAccess>();
        }

        /// <summary>
        /// Configure Repository services
        /// </summary>
        private static void AddRepositoryService(IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
        }

    }
}
