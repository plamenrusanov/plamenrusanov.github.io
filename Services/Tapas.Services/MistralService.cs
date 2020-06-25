namespace Tapas.Services
{
    using Tapas.Services.Contracts;

    public class MistralService : IMistralService
    {
        private readonly string password;

        public MistralService(string password)
        {
            this.password = password;
        }
    }
}
