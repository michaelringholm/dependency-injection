using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs;

[assembly: WebJobsStartup(typeof(com.opusmagus.Startup), "My startup")]
namespace com.opusmagus
{
    public class Startup : IWebJobsStartup {
        
        private IServiceProvider serviceProvider = null;

        public void Configure(IWebJobsBuilder builder)
        {
            //builder.Services.AddSingleton<InjectBindingProvider>();
             //Registering an extension
             //builder.AddExtension<InjectConfiguration>(); //AddExtension returns a builder that allows extending the configuration model
             var services = builder.Services;
             var serviceProvider = services.BuildServiceProvider();
             if(serviceProvider == null) {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<IOrderPersister, OrderFilePersister>();
                serviceProvider = serviceCollection.BuildServiceProvider();
            }
            
             var logger = serviceProvider.GetService<ILogger>();
             if(logger != null)
                logger.LogInformation("Startup.Configure() was called!");
        }

        public IServiceProvider CreateServiceProvider()
        {
            //Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
            /*
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                Configuration = builder.Build();
             */
            new ConfigurationBuilder().AddEnvironmentVariables();
            //IHostingEnvironment a;
            //a.IsDevelopment();
            if(serviceProvider == null) {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<IOrderPersister, OrderFilePersister>();
                serviceProvider = serviceCollection.BuildServiceProvider();
            }
            return serviceProvider;
        }
    }
}
