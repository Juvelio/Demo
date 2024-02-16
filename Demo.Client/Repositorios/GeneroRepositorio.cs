using Demo.Shared.Entidades;
using System.Text.Json;

namespace Demo.Client.Repositorios
{
    public class GeneroRepositorio
    {
        private readonly HttpClient httpClient;
        private readonly string BaseUrl;

        public GeneroRepositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            BaseUrl = "https://localhost:7288/";
        }

        private JsonSerializerOptions OpcionesPorDefectoJSON => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<Genero>> Get(string url)
        {
            url = BaseUrl + url;

            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {               
                //obtengo el JSON
                var respuestajson = await httpResponse.Content.ReadAsStringAsync();
                var generos = System.Text.Json.JsonSerializer.Deserialize<List<Genero>>(respuestajson, OpcionesPorDefectoJSON);
                return generos;
            }
            else
            {
                return new List<Genero>();
            }
        }


        public async Task<Genero> GetGenero(string url)
        {
            url = BaseUrl + url;

            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                var respuestajson = await httpResponse.Content.ReadAsStringAsync();
                var genero = System.Text.Json.JsonSerializer.Deserialize<Genero>(respuestajson, OpcionesPorDefectoJSON);
                return genero;
            }
            else
            {
                return new Genero();
            }
        }

        public async Task<bool> Post(string url, Genero genero)
        {
            url = BaseUrl + url;
            var enviarJSON = System.Text.Json.JsonSerializer.Serialize(genero);
            var enviarContenido = new StringContent(enviarJSON, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(url, enviarContenido);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Put(string url, Genero genero)
        {
            url = BaseUrl + url;
            var enviarJSON = System.Text.Json.JsonSerializer.Serialize(genero);
            var enviarContenido = new StringContent(enviarJSON, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PutAsync(url, enviarContenido);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<bool> Delete(string url)
        {
            url = BaseUrl + url;

            var httpResponse = await httpClient.DeleteAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
