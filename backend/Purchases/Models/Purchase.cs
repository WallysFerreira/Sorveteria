using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Purchases.Models;
public class Purchase {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Usuario { get; set; }
    public string Produto { get; set; }

    public Purchase(string usuario, string produto){
        this.Usuario = usuario;
        this.Produto = produto;
    }

}