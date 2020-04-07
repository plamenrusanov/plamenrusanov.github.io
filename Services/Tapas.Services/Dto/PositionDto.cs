namespace Tapas.Services.Dto
{
    public class PositionDto
    {
        public string display_name { get; set; }

        public string lat { get; set; }

        public string lon { get; set; }

        public AddressDto Address { get; set; }
    }
}
