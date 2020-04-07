namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Data.Models;
    using Tapas.Web.ViewModels.Addreses;

    public interface IAddresesService
    {
        ICollection<AddressViewModel> GetMyAddreses(ApplicationUser user);

        Task<AddressInputModel> GetAddressAsync(string latitude, string longitude);
    }
}
