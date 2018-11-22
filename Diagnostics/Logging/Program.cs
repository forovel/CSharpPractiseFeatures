using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Logging
{
    class Program
    {
        private static ServiceProvider _provider;
        private static readonly string url = "https://csharp.christiannagel.com";

        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            _provider = DependancyInjection.RegisterDependancies(configuration);

            var result = _provider.GetService<SampleController>().NetwrokRequestSampleAsync(url).GetAwaiter();

            Console.ReadLine();
        }
    }
}
