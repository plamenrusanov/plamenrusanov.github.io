namespace Tapas.Services.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudService
    {
        Task<string> UploadImageToCloud(IFormFile formFile);
    }
}
