namespace Tapas.Services
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Tapas.Services.Contracts;
    using Tapas.Services.Dto;

    public class GeolocationService : IGeolocationService
    {
        private readonly string apiKey;

        public GeolocationService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<PositionDto> GetAddressAsync(string latitude, string longitude)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("bg", 0.8));

                var result = await client.GetAsync($"https://eu1.locationiq.com/v1/reverse.php?key={this.apiKey}&lat={latitude}&lon={longitude}&format=json");
                var resultContent = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PositionDto>(resultContent);
            }
        }
    }
}
