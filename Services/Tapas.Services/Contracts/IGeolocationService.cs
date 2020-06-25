namespace Tapas.Services.Contracts
{
    using System.Threading.Tasks;

    using Tapas.Services.Dto.Geolocation;

    public interface IGeolocationService
    {
        Task<PositionDto> GetAddressAsync(string latitude, string longitude);
    }
}
