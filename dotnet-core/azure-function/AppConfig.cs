using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace com.opusmagus
{
    public static class AppConfig {
        private static IServiceProvider serviceProvider = null;
        public static IServiceProvider CreateServiceProvider()
        {
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
