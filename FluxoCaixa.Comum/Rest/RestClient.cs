using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Comum.Rest
{
    public class RestClient
    {
        private readonly HttpClient _httpClient;

        public RestClient(string baseUri)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUri) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAsync(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException($"Erro na requisição GET para {endpoint}. Status: {response.StatusCode}");
        }

        public async Task<string> PostAsync(string endpoint, string content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, new StringContent(content, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException($"Erro na requisição POST para {endpoint}. Status: {response.StatusCode}");
        }
    }
}
