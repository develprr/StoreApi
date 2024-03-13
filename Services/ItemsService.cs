using StoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


public class ItemsService
{
    private readonly IMongoCollection<Item> _itemsCollection;

    public ItemsService(
        IOptions<StoreDatabaseSettings> StoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            StoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            StoreDatabaseSettings.Value.DatabaseName);

        _itemsCollection = mongoDatabase.GetCollection<Item>(
            StoreDatabaseSettings.Value.ItemsCollectionName);
    }

    public async Task<List<Item>> GetAsync() =>
        await _itemsCollection.Find(_ => true).ToListAsync();

    public async Task<Item?> GetAsync(string id) =>
        await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Item newItem) =>
        await _itemsCollection.InsertOneAsync(newItem);

    public async Task UpdateAsync(string id, Item updateItem) =>
        await _itemsCollection.ReplaceOneAsync(x => x.Id == id, updateItem);

    public async Task RemoveAsync(string id) =>
        await _itemsCollection.DeleteOneAsync(x => x.Id == id);
}