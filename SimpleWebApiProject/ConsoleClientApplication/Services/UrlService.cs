namespace ConsoleClientApplication.Services
{
    public class UrlService
    {
        public string BaseAddress { get; }
        public string BooksApi { get; }

        public UrlService()
        {
            BaseAddress = "http://localhost:65471/";
            BooksApi = "api/BookChapters";
        }
    }
}
