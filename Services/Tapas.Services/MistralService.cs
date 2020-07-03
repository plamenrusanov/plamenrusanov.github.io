namespace Tapas.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using RestSharp;
    using Tapas.Services.Contracts;
    using Tapas.Services.Dto.Mistral;

    public class MistralService : IMistralService
    {
        private const string UserName = "1";
        private readonly string password;

        public MistralService(string password)
        {
            this.password = password;
        }

        // http://localhost:51981/api/GetAllData?locationid=1&search=nameOrId
        public async Task<ICollection<ProductMDto>> GetAllData(int locationId, string search = null)
        {
          /*  var client = new RestClient("http://localhost:51981/api/GetAllData");
            client.Timeout = -1; */

            try
            {
                /*  var request = await this.GetRequestAsync();
                  request.AddParameter("locationId", locationId);
                  request.AddParameter("search", search);
                  IRestResponse response = await client.ExecuteGetAsync(request);
                  if (response.IsSuccessful)
                  {
                      return JsonConvert.DeserializeObject<ICollection<ProductMDto>>(response.Content);
                  } */
                if (search is null)
                {
                    return JsonConvert.DeserializeObject<ICollection<ProductMDto>>(await File.ReadAllTextAsync(@"C:\Users\user\source\repos\Tapas\Services\Tapas.Services\Resources\allData.json"));
                }

                var dto = JsonConvert.DeserializeObject<ICollection<ProductMDto>>(File.ReadAllText(@"C:\Users\user\source\repos\Tapas\Services\Tapas.Services\Resources\allData.json"));

                return dto.Where(x => x.Name == search).ToList();

                throw new Exception("Request failed!");
            }
            catch (Exception e)
            {
                if (e.InnerException is null)
                {
                    throw new Exception(e.InnerException.Message);
                }

                throw new Exception(e.Message);
            }
        }

        // http://localhost:51981/api/Locations
        public async Task<ICollection<LocationMDto>> Locations()
        {
            var client = new RestClient("http://localhost:51981/api/Locations");
            client.Timeout = -1;
            try
            {
                var request = await this.GetRequestAsync();
                IRestResponse response = await client.ExecuteGetAsync(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ICollection<LocationMDto>>(response.Content);
                }

                throw new Exception("Request failed!");
            }
            catch (Exception e)
            {
                if (e.InnerException is null)
                {
                    throw new Exception(e.InnerException.Message);
                }

                throw new Exception(e.Message);
            }
        }

        // POST http://localhost:51981/api/SaveWebOrde
        public Task SaveWebOrder(OrderMDto order)
        {
            throw new System.NotImplementedException();
        }

        // http://localhost:51981/api/Storages
        public async Task<ICollection<StorageMDto>> Storages()
        {
            var client = new RestClient("http://localhost:51981/api/Storages");
            client.Timeout = -1;
            try
            {
                var request = await this.GetRequestAsync();
                IRestResponse response = await client.ExecuteGetAsync(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<ICollection<StorageMDto>>(response.Content);
                }

                throw new Exception("Request failed!");
            }
            catch (Exception e)
            {
                if (e.InnerException is null)
                {
                    throw new Exception(e.InnerException.Message);
                }

                throw new Exception(e.Message);
            }
        }

        private async Task<RestRequest> GetRequestAsync()
        {
            TokenMDto tokenDto;
            try
            {
                tokenDto = await this.GetTokenAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {tokenDto.Token}");
            return request;
        }

        private async Task<TokenMDto> GetTokenAsync()
        {
            var client = new RestClient("http://localhost:51981/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", UserName);
            request.AddParameter("password", $"{this.password}");
            IRestResponse response = await client.ExecutePostAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<TokenMDto>(response.Content);
            }

            throw new Exception(message: "Authorization failed!");
        }
    }
}
