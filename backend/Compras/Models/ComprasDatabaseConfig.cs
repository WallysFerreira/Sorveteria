namespace Compras.Models;

public class ComprasDatabaseConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ComprasCollectionName { get; set; } = null!;
}