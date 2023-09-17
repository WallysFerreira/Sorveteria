using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Compras.Models;
public class Compra {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Usuario { get; set; }
    public string Produto { get; set; }

    public Compra(string usuario, string produto){
        this.Usuario = usuario;
        this.Produto = produto;
    }

}