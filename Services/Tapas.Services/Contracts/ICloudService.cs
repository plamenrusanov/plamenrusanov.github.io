namespace Tapas.Services.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudService
    {
        Task<string> UploadImageFromForm(IFormFile formFile);

        Task<string> UploadImageFromResources(string fileDirectory);
    }
}
