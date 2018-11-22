using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using xUnitConsoleApplication.Services;

namespace xUnitConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider container = DependancyContainer.RegisterDependancy();

            var result = container.GetService<IBookService>().GetTopTenBooks("test");

            container.Dispose();

            result.ToList().ForEach(x => Console.WriteLine(x.Publisher));

            Console.ReadLine();
        }

    }
}
