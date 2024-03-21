using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Purchases.Models;
public class Purchase {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string UserID { get; set; }
    public string[] Products { get; set; }
    public DateTime? CreatedAt { get; set; }

    public Purchase(string userID, string[] products){
        this.UserID = userID;
        this.Products = products;
        this.CreatedAt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Brazil/East"));
    }

}