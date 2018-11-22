using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public static class DependancyInjection
    {
        public static ServiceProvider RegisterDependancies(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddLogging(builder => 
            {
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddConsole();
                
                #if DEBUG
                builder.AddDebug();
                #endif
            });

            services.AddTransient<SampleController>();
            return services.BuildServiceProvider();
        }
    }
}
