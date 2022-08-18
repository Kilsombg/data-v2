using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PrettoPall.Data.Models;

namespace PrettoPall.Api.Services;

public class MongoDBService
{

    private readonly IMongoCollection<Player> playerCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        this.playerCollection= database.GetCollection<Player>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Player>> GetAsync() {
        return await playerCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task CreateAsync(Player player) {
        await playerCollection.InsertOneAsync(player);
        return;
    }
    public async Task AddToPlaylistAsync(string id, string movieId) { }
    public async Task DeleteAsync(string id) { }

}