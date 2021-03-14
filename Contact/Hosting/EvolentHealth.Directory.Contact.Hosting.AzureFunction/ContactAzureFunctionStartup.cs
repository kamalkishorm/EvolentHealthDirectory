using EvolentHealth.Directory.Contact.Contract;
using EvolentHealth.Directory.Contact.Contract.Configurations;
using EvolentHealth.Directory.Contact.Hosting.AzureFunction;
using EvolentHealth.Directory.Core.AspNet;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using EvolentHealth.Directory.Contact.Hosting.Bootstrap.Configuration.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly:FunctionsStartup(typeof(ContactAzureFunctionsStartup))]

namespace EvolentHealth.Directory.Contact.Hosting.AzureFunction
{
    public class ContactAzureFunctionsStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configurations = DirectoryFunctionAppBuilder.CreatFunctionAppConfiguration();
            builder.Services.Configure<ContactConfiguration>(configurations.GetSection("ContactSettings"));
            builder.Services.AddSingleton(resolve =>
                resolve.GetRequiredService<IOptions<ContactConfiguration>>().Value);
            var contactConfiguration = builder.Services.BuildServiceProvider().GetService<ContactConfiguration>();
            var hostEnvironment = builder.Services.BuildServiceProvider().GetService<IHostEnvironment>();
            builder.Services.AddContactServices(contactConfiguration, hostEnvironment.IsDevelopment());
        }
    }
}