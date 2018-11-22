using System.Collections.Generic;

namespace SimpleCoreServer.Web.Services
{
    public class SimpleService : ISimpleService
    {
        public IEnumerable<string> GetSamples()
        {
            return new List<string> { "one", "two", "three" };
        }
    }
}
