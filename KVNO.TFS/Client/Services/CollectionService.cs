using KVNO.TFS.Shared.Models;
using System.Net.Http.Json;

namespace KVNO.TFS.Client.Services
{
    public class CollectionService
    {
        private readonly HttpClient _http;
        public CollectionService(IServiceProvider service)
        {
            _http = service.GetRequiredService<HttpClient>();
        }

        public async Task<DevOpsCollection[]?> GetCollections()
        {
            var collections = await _http.GetFromJsonAsync<DevOpsCollection[]>("api/collection");
            return collections;
        }
        public async Task<DevOpsCollection?> GetCollectionById(string collectionId)
        {
            var collection = await _http.GetFromJsonAsync<DevOpsCollection>($"api/collection/id?collectionId={collectionId}");
            return collection;
        }
    }
}
