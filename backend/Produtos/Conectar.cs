using MySqlConnector;
using Produtos.Models;

namespace Produtos;

public class Conectar {
    public static async void Inserir(Produto prod) {
        Console.WriteLine("Fui chamado");

        try {
        var connection = new MySqlConnection("Server=localhost;User ID=root;Password=root;Database=Produtos");
        await connection.OpenAsync();

        var queryInsert = new MySqlCommand("INSERT INTO Produtos (Categoria, Nome, Preco, Descricao, Foto) VALUES (@c, @n, @p, @d, @f)", connection);
        queryInsert.Parameters.AddWithValue("c", prod.Categoria);
        queryInsert.Parameters.AddWithValue("n", prod.Nome);
        queryInsert.Parameters.AddWithValue("p", prod.Preco);
        queryInsert.Parameters.AddWithValue("d", prod.Descricao);
        queryInsert.Parameters.AddWithValue("f", prod.Foto);

        await queryInsert.ExecuteNonQueryAsync();
        } catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}