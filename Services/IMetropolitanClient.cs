using Metropolitan.Models;
using Pathoschild.Http.Client;
using System.Threading.Tasks;

namespace Metropolitan.Services
{
    public interface IMetropolitanClient
    {
        FluentClient _client { get; set; }
        Task<GetObjectsResponse> getObjects(GetObjectsRequest input);

        Task<GetObjectResponse> getObjectDetails(int id);
    }
}