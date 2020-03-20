namespace Tapas.Services
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Tapas.Services.Contracts;

    public class CloudService : ICloudService
    {
        private readonly CloudConnection cloudConnection;

        public CloudService(CloudConnection cloudConnection)
        {
            this.cloudConnection = cloudConnection;
        }

        public async Task<string> UploadImageToCloud(IFormFile formFile)
        {
            Stream stream = formFile.OpenReadStream();
            var imageName = Guid.NewGuid().ToString();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageName, stream),
            };
            var uploadResult = this.cloudConnection.Cloudinary().Upload(uploadParams);
            return await Task.FromResult<string>(uploadResult.Uri.AbsolutePath);
        }
    }
}
