namespace Tapas.Services.Dto.Geolocation
{
    using System.ComponentModel;

    public class AddressDto
    {
        [DisplayName("address29")]
        public string Address29 { get; set; }

        [DisplayName("house_number")]
        public string HouseNumber { get; set; }

        [DisplayName("road")]
        public string Road { get; set; }

        [DisplayName("neighbourhood")]
        public string Neighbourhood { get; set; }

        [DisplayName("suburb")]
        public string Suburb { get; set; }

        [DisplayName("city")]
        public string City { get; set; }
    }
}
