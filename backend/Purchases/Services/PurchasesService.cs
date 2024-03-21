using System.Diagnostics.Eventing.Reader;
using Purchases.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Purchases.Services;

public class PurchasesService
{
    private readonly IMongoCollection<Purchase> _purchasesCollection;

    public PurchasesService()
    {
        string dbUrl = Environment.GetEnvironmentVariable("DB_URL");
        string dbName = Environment.GetEnvironmentVariable("DB_NAME");
        string dbColName = Environment.GetEnvironmentVariable("DB_COL_NAME");

        var mongoClient = new MongoClient(dbUrl);

        var mongoDatabase = mongoClient.GetDatabase(dbName);

        _purchasesCollection = mongoDatabase.GetCollection<Purchase>(dbColName);
    }

    public async Task<List<Purchase>> GetAsync() =>
        await _purchasesCollection.Find( _ => true).ToListAsync();

    public async Task<Purchase?> GetAsync(string id) =>
        await _purchasesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Purchase newPurchase) =>
        await _purchasesCollection.InsertOneAsync(newPurchase);

    public async Task UpdateAsync(string id, Purchase updatedPurchase) =>
        await _purchasesCollection.ReplaceOneAsync(x => x.Id == id, updatedPurchase);

    public async Task RemoveAsync(string id) =>
        await _purchasesCollection.DeleteOneAsync(x => x.Id == id);
}