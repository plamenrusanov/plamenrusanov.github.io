namespace Tapas.Services.Dto.Geolocation
{
    using Newtonsoft.Json;

    public class PositionDto
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }

        [JsonProperty("display_name")]
        public AddressDto Address { get; set; }
    }
}
