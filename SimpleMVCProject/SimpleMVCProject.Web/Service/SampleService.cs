using System.Collections.Generic;

namespace SimpleMVCProject.Web.Service
{
    public class SampleService : ISampleService
    {
        public IEnumerable<string> GetSampleStrings()
        {
            return new string[] { "one", "two", "three", "four" };
        }
    }
}
