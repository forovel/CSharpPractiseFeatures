using ConsoleClientApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ClientAppWait for service");
            var service = DependancyContainer.RegisterDependancy();

            var test = service.GetRequiredService<SampleRequest>();

            test.ReadChaptersAsync().GetAwaiter().GetResult();
            test.ReadChapterAsync().GetAwaiter().GetResult();
            test.ReadNotExistingChapterAsync().GetAwaiter().GetResult();
            test.ReadXmlAsync().GetAwaiter().GetResult();
            test.AddChapterAsync().GetAwaiter().GetResult();
            test.UpdateChapterAsync().GetAwaiter().GetResult();
            test.RemoveChapterAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
