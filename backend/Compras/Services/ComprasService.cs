using System.Diagnostics.Eventing.Reader;
using Compras.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Compras.Services;

public class ComprasService
{
    private readonly IMongoCollection<Compra> _comprasCollection;

    public ComprasService(
        IOptions<ComprasDatabaseConfig> comprasDatabaseConfig)
    {
        var mongoClient = new MongoClient(
            comprasDatabaseConfig.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            comprasDatabaseConfig.Value.DatabaseName);

        _comprasCollection = mongoDatabase.GetCollection<Compra>(
            comprasDatabaseConfig.Value.ComprasCollectionName);
    }

    public async Task<List<Compra>> GetAsync() =>
        await _comprasCollection.Find( _ => true).ToListAsync();

    public async Task<Compra?> GetAsync(string id) =>
        await _comprasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Compra newCompra) =>
        await _comprasCollection.InsertOneAsync(newCompra);

    public async Task UpdateAsync(string id, Compra updatedCompra) =>
        await _comprasCollection.ReplaceOneAsync(x => x.Id == id, updatedCompra);

    public async Task RemoveAsync(string id) =>
        await _comprasCollection.DeleteOneAsync(x => x.Id == id);
}