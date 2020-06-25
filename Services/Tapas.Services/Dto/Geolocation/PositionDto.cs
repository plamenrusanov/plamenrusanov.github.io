namespace Tapas.Services.Dto.Geolocation
{
    using System.ComponentModel;

    public class PositionDto
    {
        [DisplayName("display_name")]
        public string DisplayName { get; set; }

        [DisplayName("lat")]
        public string Latitude { get; set; }

        [DisplayName("lon")]
        public string Longitude { get; set; }

        [DisplayName("display_name")]
        public AddressDto Address { get; set; }
    }
}
