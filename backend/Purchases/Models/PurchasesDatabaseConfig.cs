namespace Purchases.Models;

public class PurchasesDatabaseConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string PurchasesCollectionName { get; set; } = null!;
}