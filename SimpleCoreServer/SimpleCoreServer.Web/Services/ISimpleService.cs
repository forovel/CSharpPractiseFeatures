using System.Collections.Generic;

namespace SimpleCoreServer.Web.Services
{
    public interface ISimpleService
    {
        IEnumerable<string> GetSamples();
    }
}
