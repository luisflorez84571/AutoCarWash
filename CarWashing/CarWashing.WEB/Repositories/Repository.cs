using System.Text;
using System.Text.Json;

namespace CarWashing.WEB.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<object>> GetAsync(string url)
        {
            var responseHTTP = await _httpClient.GetAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswerAsync<T>(responseHttp);
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }

            return new HttpResponseWrapper<T>(default, true, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContet = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContet);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }
        //-- inicio
        public async Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T model)
        {
            try
            {
                var messageJSON = JsonSerializer.Serialize(model);
                var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");

                var responseHttp = await _httpClient.PostAsync(url, messageContent);

                if (responseHttp.IsSuccessStatusCode)
                {
                    var response = await UnserializeAnswerAsync<TResponse>(responseHttp);
                    return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
                }

                // Manejo de errores
                var errorResponse = await responseHttp.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en la solicitud POST a {url}. Estado: {responseHttp.StatusCode}. Mensaje: {errorResponse}");

                return new HttpResponseWrapper<TResponse>(default, !responseHttp.IsSuccessStatusCode, responseHttp);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Excepción en PostAsync: {ex.Message}");
                return new HttpResponseWrapper<TResponse>(default, true, null);
            }
        }



        //--fin ------------------------
        

        public async Task<HttpResponseWrapper<object>> DeleteAsync(string url)
        {
            var responseHttp = await _httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model)
        {
            var messageJson = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJson, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PutAsync(url, messageContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> PutAsync<T, TResponse>(string url, T model)
        {
            var messageJson = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJson, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PutAsync(url, messageContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswerAsync<TResponse>(responseHttp);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
        }

        private async Task<T> UnserializeAnswerAsync<T>(HttpResponseMessage responseHttp)
        {
            var response = await responseHttp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, _jsonDefaultOptions)!;
        }
    }
}