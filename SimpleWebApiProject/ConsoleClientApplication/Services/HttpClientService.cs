using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleClientApplication.Services
{
    public abstract class HttpClientService<T> : IDisposable where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly UrlService _urlService;

        public HttpClientService(UrlService urlService)
        {
            _urlService = urlService;
            _httpClient = new HttpClient();
        }

        public async virtual Task<T> GetAsync(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));

            string json = await GetInternalAsync(requestUri);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));

            string json = await GetInternalAsync(requestUri);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        public async Task<XElement> GetAllXmlAsync(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlService.BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage resp = await client.GetAsync(requestUri);
                resp.EnsureSuccessStatusCode();

                string xml = await resp.Content.ReadAsStringAsync();
                XElement chapters = XElement.Parse(xml);

                return chapters;
            }
        }

        public async Task<T> PostAsync(string requestUri, T item)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_disposed == true) throw new ObjectDisposedException(nameof(_httpClient));

            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _httpClient.PostAsync(requestUri, content);
            resp.EnsureSuccessStatusCode();

            json = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task PutAsync(string requestUri, T item)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_disposed == true) throw new ObjectDisposedException(nameof(_httpClient));

            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _httpClient.PutAsync(requestUri, content);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));
            if (_disposed == true) throw new ObjectDisposedException(nameof(_httpClient));

            HttpResponseMessage resp = await _httpClient.DeleteAsync(requestUri);
            resp.EnsureSuccessStatusCode();
        }

        private async Task<string> GetInternalAsync(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri)) throw new ArgumentNullException(nameof(requestUri));
            if (_disposed == true) throw new ObjectDisposedException(nameof(_httpClient));

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                    GC.SuppressFinalize(this);
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
