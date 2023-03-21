namespace KVNO.TFS.Client.Services;

public class CollectionService : ICollectionService
{
    private readonly HttpClient _http;
    public CollectionService(HttpClient http)
    {
        _http = http;
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
