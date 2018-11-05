﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace samples.dependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DepedencyInjection demo Started!");

            Console.WriteLine();
            Console.WriteLine("*********** Using DI ************");
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var diContainer = new ServiceCollection();
            diContainer.AddSingleton<ISecurityVault, SimpleKeyVault>();
            diContainer.AddSingleton<IConfigurationRoot>(builder.Build());
            diContainer.AddSingleton<SomeClass, SomeClass>(); // Added to show constructor injection

            var diProvider = diContainer.BuildServiceProvider();
            var securityVault = diProvider.GetService<ISecurityVault>(); 
            var someObject = diProvider.GetService<SomeClass>(); // The above will often be injected in the constructor
            var secret = securityVault.GetSecret("my-secret");            
            Console.WriteLine($"secret={secret}");
            var rsaPrivateKey = securityVault.GetSecret("my-rsa-private-key-secret");            
            Console.WriteLine($"key={rsaPrivateKey}");

            Console.WriteLine();
            Console.WriteLine("*********** Not using DI ************");
            var rsaPrivateKeyNonDI = new SimpleKeyVault(builder.Build()).GetSecret("my-rsa-private-key-secret");
            Console.WriteLine($"key={rsaPrivateKeyNonDI}");

            Console.WriteLine("DepedencyInjection demo Ended!");
        }
    }
}
