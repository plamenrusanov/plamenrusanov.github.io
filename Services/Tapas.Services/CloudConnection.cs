namespace Tapas.Services
{
    using CloudinaryDotNet;

    public class CloudConnection
    {
        private static Account account = new Account()
        {
            Cloud = "duxtyuzpy",
            ApiKey = "749877646312376",
            ApiSecret = "112EsZQ5gMBLCOkWC3FvH2hJsGA",
        };

        public Cloudinary Cloudinary() => new Cloudinary(account);
    }
}
