using KVNO.TFS.Server.Data;
using KVNO.TFS.Shared.Models;

namespace KVNO.TFS.Server.DL
{
    public class CollectionLogic
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _conf;
        private readonly ILogger<CollectionLogic> _logger;
        private readonly DevOpsDbContext _context;

        public CollectionLogic(IHttpClientFactory clientFactory, IConfiguration conf, ILogger<CollectionLogic> logger)
        {
            _http = clientFactory.CreateClient("default");
            _conf = conf;
            _logger = logger;
        }

        public async Task<DevOpsCollection[]?> GetCollectionsAsync()
        {
            var tfsCollections = await _http.GetFromJsonAsync<TFSModels.Collection.Rootobject>("_apis/projectCollections");
            if(tfsCollections is not null)
            {
                List<DevOpsCollection> collections = new();
                foreach (var collection in tfsCollections.value) 
                {
                    collections.Add(new DevOpsCollection()
                    {
                        Id = collection.id,
                        Name = collection.name,
                        Url = collection.url
                    });
                }
                return collections.ToArray();
            }
            return null;
        }

        public async Task<DevOpsCollection> GetCollectionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
