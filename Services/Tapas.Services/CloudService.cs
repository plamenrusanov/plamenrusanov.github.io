﻿namespace Tapas.Services
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
        private readonly Account account;

        public CloudService(string cloudName, string apiKey, string apiSecret)
        {
            this.account = new Account()
            {
                Cloud = cloudName,
                ApiKey = apiKey,
                ApiSecret = apiSecret,
            };
        }

        public async Task<string> UploadImageFromForm(IFormFile formFile)
        {
            Stream stream = formFile.OpenReadStream();
            var imageName = Guid.NewGuid().ToString();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageName, stream),
            };

            var uploadResult = this.Cloudinary().Upload(uploadParams);

            var url = uploadResult.Uri.AbsolutePath.Insert(24, "f_auto/");
            return await Task.FromResult<string>(url);
        }

        public async Task<string> UploadImageFromResources(string fileDirectory)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileDirectory),
            };

            var uploadResult = this.Cloudinary().Upload(uploadParams);
            return await Task.FromResult<string>(uploadResult.Uri.AbsolutePath);
        }

        private Cloudinary Cloudinary() => new Cloudinary(this.account);
    }
}
