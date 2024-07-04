using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Sistema_Inmobiliaria.Models
{
    public class ReniecService
    {
        private static readonly string apiUrl = "https://api.apis.net.pe/v2/reniec/dni?numero=";
        private static readonly string token = "apis-token-9330.-ht5XqpQYrr08oKwOeVrI9FCqJbsxNuE";

        public async Task<DniResponse> ConsultarDniAsync(string dni)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Referer", "https://apis.net.pe/consulta-dni-api");

                var url = apiUrl + dni;
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DniResponse>(content);
                }

                return null;
            }
        }
    }
}