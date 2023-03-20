using KVNO.TFS.Client.Services;
using KVNO.TFS.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using Xunit;

namespace KVNO.TFS.Client.Tests;

public class CollectionTests
{
    private readonly CollectionService _cs;
    public CollectionTests()
    {
        var sp = new DI().Start().Result;
        _cs = sp.GetRequiredService<CollectionService>();
    }

    [Fact]
    public async Task Get_All_Collections_From_Server()
    {
        var collections = await _cs.GetCollections();
        Assert.InRange(collections.Length,1,int.MaxValue);
    }

    [Theory]
    [InlineData("054a1095-4850-489d-b0f4-52ad100c9006")]
    [InlineData("3d305a43-835a-48b1-8f3a-ddffcfef3bee")]
    [InlineData("a235c705-421e-4268-8f49-48765288468d")]
    public async Task Get_A_Collection_From_Server_By_ID(string collectionId)
    {
        var collection = await _cs.GetCollectionById(collectionId);
        Assert.NotNull(collection);
    }
}
