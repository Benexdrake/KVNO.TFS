namespace KVNO.TFS.Server.DL;

public class CollectionLogic : ICollectionLogic
{
    private readonly HttpClient _http;
    private readonly IConfiguration _conf;
    private readonly ILogger<CollectionLogic> _logger;
    private readonly DevOpsDbContext _context;

    public CollectionLogic(IHttpClientFactory clientFactory, IConfiguration conf, ILogger<CollectionLogic> logger, DevOpsDbContext context)
    {
        _http = clientFactory.CreateClient("default");
        _conf = conf;
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Gets an Array from DevOpsCollection from the DevOps API
    /// </summary>
    /// <returns></returns>
    public async Task<DevOpsCollection[]?> GetCollectionsAsync()
    {
        try
        {
            List<DevOpsCollection> devOpsCollections = new List<DevOpsCollection>();
            var tfsCollections = await _http.GetFromJsonAsync<TFSModels.Collection.Rootobject>("_apis/projectCollections");
            if (tfsCollections is not null)
            {
                foreach (var collection in tfsCollections.value)
                {
                    var c = new DevOpsCollection()
                    {
                        Id = collection.id,
                        Name = collection.name
                    };
                    devOpsCollections.Add(c);
                    await CreateOrUpdate(c);
                }
                return devOpsCollections.ToArray();
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
        return null;
    }

    public async Task CreateOrUpdate(DevOpsCollection c)
    {
        try
        {
            var cDb = _context.Collections.FirstOrDefault(x => x.Id.Equals(c.Id));
            if (cDb is null)
            {
                _context.Collections.Add(c);
                await _context.SaveChangesAsync();
            }
            else
            {
                cDb.Name = c.Name;
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
    }
}
