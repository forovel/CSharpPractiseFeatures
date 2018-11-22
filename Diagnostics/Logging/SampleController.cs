using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Logging
{
    public class SampleController
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        public async Task NetwrokRequestSampleAsync(string url)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.Netwroking, $"NetwrokRequestSampleAsync started with url {url}");
                var client = new HttpClient();

                string result = await client.GetStringAsync(url);
                _logger.LogInformation(LoggingEvents.Netwroking, $"NetwrokRequestSampleAsync completed, received {result.Length}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggingEvents.Netwroking, ex, $"Error NetwrokRequestSampleAsync, error message: {ex.Message}, HResult: {ex.HResult}");
            }
        }
    }
}
