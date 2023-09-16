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

    public static async Task<List<Produto>> PegarTodos() {
        List<Produto> produtos = new();

        try {
            var connection = new MySqlConnection("Server=localhost;User ID=root;Password=root;Database=Produtos");
            await connection.OpenAsync();

            var querySelect = new MySqlCommand("SELECT * FROM Produtos", connection);
            var reader = await querySelect.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                Produto prod = new Produto(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                produtos.Add(prod);
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return produtos;
    }
}