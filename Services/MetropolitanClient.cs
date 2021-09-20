using Metropolitan.Models;
using Pathoschild.Http.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Metropolitan.Services
{
    public class MetropolitanClient : IMetropolitanClient
    {
        public FluentClient _client { get; set; }
        
        public MetropolitanClient()
        {
            _client = new FluentClient("https://collectionapi.metmuseum.org/public/collection/v1");
        }

        public async Task<GetObjectsResponse> getObjects(GetObjectsRequest input)
        {
            var result = await _client.GetAsync($"objects").WithArguments(input).As<GetObjectsResponse>();
            if (result == null)
            {
                throw new Exception("No data found please check your connection");
            }
            return result;
        }


        public async Task<GetObjectResponse> getObjectDetails(int id)
        {
            var result = await _client.GetAsync($"objects/{id}").As<GetObjectResponse>();
                if (result == null)
                {
                    throw new Exception("No data found please check your connection");
                }
                return result;            
        }

    }
}
