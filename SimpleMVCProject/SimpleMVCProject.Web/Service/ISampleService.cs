using System.Collections.Generic;

namespace SimpleMVCProject.Web.Service
{
    public interface ISampleService
    {
        IEnumerable<string> GetSampleStrings();
    }
}
