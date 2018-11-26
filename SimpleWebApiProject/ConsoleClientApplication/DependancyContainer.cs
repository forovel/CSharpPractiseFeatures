using ConsoleClientApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleClientApplication
{
    public static class DependancyContainer
    {
        public static IServiceProvider RegisterDependancy()
        {
            var service = new ServiceCollection();
            service.AddSingleton<UrlService>();
            service.AddSingleton<BookChapterClientService>();
            service.AddTransient<SampleRequest>();
            return service.BuildServiceProvider();
        }
    }
}
