namespace Tapas.Services.Contracts
{
    using System.Threading.Tasks;

    using Tapas.Services.Dto;

    public interface IGeolocationService
    {
        Task<PositionDto> GetAddressAsync(string latitude, string longitude);
    }
}
