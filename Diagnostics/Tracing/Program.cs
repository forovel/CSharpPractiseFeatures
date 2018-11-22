using System;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tracing
{
    class Program
    {
        private static readonly EventSource sampleEventSource = new EventSource("Progect-events");

        static void Main(string[] args)
        {
            Console.WriteLine($"Log GUID: {sampleEventSource.Guid}");
            Console.WriteLine($"Name: {sampleEventSource.Name}");
            sampleEventSource.Write("Startup", new { Info = "started app" });
            NetworkRequestSample().GetAwaiter().GetResult();
            Console.ReadLine();
            sampleEventSource?.Dispose();
        }

        private static async Task NetworkRequestSample()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = "http://www.cninnovation.com";
                    sampleEventSource.Write("Network", new { Info = $"requesting {url}" });
                    string result = await client.GetStringAsync(url);
                    sampleEventSource.Write("Network", new { Info = $"completed call to {url}, result string length: {result.Length}" });
                }
            }
            catch (Exception ex)
            {
                sampleEventSource.Write("Newtwork Error",
                    new EventSourceOptions { Level = EventLevel.Error },
                    new { Info = $"{ex.Message}", Result = $"{ex.HResult}" });
            }
        }
    }
}
