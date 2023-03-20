using KVNO.TFS.Server.Data;
using KVNO.TFS.Server.DL;
using KVNO.TFS.Server.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KVNO.TFS.Server.Tests
{
    public class CollectionTests
    {

        private readonly ICollectionLogic _logic;
        private readonly DevOpsDbContext _context;
        public CollectionTests()
        {
            var sp = new DI().Start().Result;
            _logic = sp.GetRequiredService<ICollectionLogic>();
            _context = sp.GetRequiredService<DevOpsDbContext>();
        }

        [Fact]
        public async Task Get_Collection_From_AzureDevops()
        {
            var test1 = await _logic.GetCollectionsAsync();
            Assert.NotNull(test1);
        }

        [Fact]
        public void Get_Collection_From_Database()
        {
            var test = _context.Collections.ToList();
            Assert.Equal(3, test.Count);
        }

        [Theory]
        [InlineData("it")]
        [InlineData("KV_extern")]
        [InlineData("Pilot")]
        public async Task Looking_For_Collection_Name_From_AzureDevOps(string collectionName)
        {
            var collections = await _logic.GetCollectionsAsync();
            var collection = collections.FirstOrDefault(x => x.Name.Equals(collectionName));
            Assert.NotNull(collection);
        }

        [Theory]
        [InlineData("it")]
        [InlineData("KV_extern")]
        [InlineData("Pilot")]
        public async Task Looking_For_Collection_Name_From_Database(string collectionName)
        {
            var collections = _context.Collections.ToList();
            var collection = collections.FirstOrDefault(x => x.Name.Equals(collectionName));
            Assert.NotNull(collection);
        }
    }
}