using System.Reflection.Metadata.Ecma335;
using MySqlConnector;
using Produtos.Models;

namespace Produtos;

public class Conectar {
    public static async Task<Produto?> Inserir(Produto prod) {

        try {
            var connection = new MySqlConnection("Server=produtosdb;User ID=root;Password=root;Database=Produtos");
            await connection.OpenAsync();

            var queryInsert = new MySqlCommand("INSERT INTO Produtos (Categoria, Nome, Preco, Descricao, Foto) VALUES (@c, @n, @p, @d, @f)", connection);
            queryInsert.Parameters.AddWithValue("c", prod.Categoria);
            queryInsert.Parameters.AddWithValue("n", prod.Nome);
            queryInsert.Parameters.AddWithValue("p", prod.Preco);
            queryInsert.Parameters.AddWithValue("d", prod.Descricao);
            queryInsert.Parameters.AddWithValue("f", prod.Foto);

            await queryInsert.ExecuteNonQueryAsync();

            connection.Close();

            await connection.OpenAsync();

            var querySelectUm = new MySqlCommand("SELECT ID FROM Produtos WHERE Nome = (@n)", connection);
            querySelectUm.Parameters.AddWithValue("n", prod.Nome);

            var reader = await querySelectUm.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod.Id = reader.GetInt16(0);
            }

        } catch (Exception e) {
            Console.WriteLine(e);
            return null;
        }

        return prod;
    }

    public static async Task<Produto?> PegarUm(int id) {
        Produto? prod = null;
        try {
            var connection = new MySqlConnection("Server=produtosdb;User ID=root;Password=root;Database=Produtos");
            await connection.OpenAsync();

            var querySelectUm = new MySqlCommand("SELECT * FROM Produtos WHERE ID = (@p)", connection);
            querySelectUm.Parameters.AddWithValue("p", id);

            var reader = await querySelectUm.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new Produto(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
            }

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return prod;
    }

    public static async Task<List<Produto>> PegarTodos() {
        List<Produto> produtos = new();

        try {
            var connection = new MySqlConnection("Server=produtosdb;User ID=root;Password=root;Database=Produtos");
            await connection.OpenAsync();

            var querySelect = new MySqlCommand("SELECT * FROM Produtos", connection);
            var reader = await querySelect.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                Produto prod = new Produto(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
                produtos.Add(prod);
            }

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return produtos;
    }

    public static async Task<Produto?> DeletarUm(int id) {
        Produto? prod = null; 

        try {
            var connection = new MySqlConnection("Server=produtosdb;User ID=mysql;Database=Produtos");
            await connection.OpenAsync();

            var querySelectUm = new MySqlCommand("SELECT * FROM Produtos WHERE ID = (@p)", connection);
            querySelectUm.Parameters.AddWithValue("p", id);

            var reader = await querySelectUm.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
            }

            connection.Close();

            if (prod == null) {
                return prod;
            }

            await connection.OpenAsync();

            var queryDelete = new MySqlCommand("DELETE FROM Produtos WHERE ID = (@p)", connection);
            queryDelete.Parameters.AddWithValue("p", id);

            await queryDelete.ExecuteNonQueryAsync();

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }
        return prod;
    }

    public static async Task<Produto?> AtualizarCampo(int id, string campo, string valor) {
        Produto? prod = null; 

        try {
            var connection = new MySqlConnection("Server=localhost;User ID=root;Password=root;Database=Produtos");
            await connection.OpenAsync();

            var querySelectUm = new MySqlCommand("SELECT * FROM Produtos WHERE ID = (@p)", connection);
            querySelectUm.Parameters.AddWithValue("p", id);

            var reader = await querySelectUm.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
            }

            connection.Close();

            if (prod == null) {
                return null;
            }

            await connection.OpenAsync();

            var queryUpdate = new MySqlCommand("UPDATE Produtos SET " + campo + " = @v WHERE ID = @p", connection);
            queryUpdate.Parameters.AddWithValue("p", id);
            queryUpdate.Parameters.AddWithValue("v", campo != "preco" ? valor : float.Parse(valor));

            await queryUpdate.ExecuteNonQueryAsync();

            connection.Close();

            await connection.OpenAsync();

            reader = await querySelectUm.ExecuteReaderAsync();
            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
            }

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return prod;
    }

    public static async Task<Produto?> AtualizarProduto(int id, Produto produto) {
        Produto? prod = null; 

        try {
            var connection = new MySqlConnection("Server=localhost;User ID=root;Password=root;Database=Produtos");
            await connection.OpenAsync();

            var querySelectUm = new MySqlCommand("SELECT * FROM Produtos WHERE ID = (@p)", connection);
            querySelectUm.Parameters.AddWithValue("p", id);

            var reader = await querySelectUm.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
            }

            connection.Close();

            if (prod == null) {
                return null;
            }

            await connection.OpenAsync();

            var queryUpdate = new MySqlCommand("UPDATE Produtos SET categoria = @c, nome = @n, descricao = @d, preco = @p, foto = @f WHERE ID = @i", connection);
            queryUpdate.Parameters.AddWithValue("i", id);
            queryUpdate.Parameters.AddWithValue("c", produto.Categoria);
            queryUpdate.Parameters.AddWithValue("n", produto.Nome);
            queryUpdate.Parameters.AddWithValue("d", produto.Descricao);
            queryUpdate.Parameters.AddWithValue("p", produto.Preco);
            queryUpdate.Parameters.AddWithValue("f", produto.Foto);

            await queryUpdate.ExecuteNonQueryAsync();

            connection.Close();

            await connection.OpenAsync();

            reader = await querySelectUm.ExecuteReaderAsync();
            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
            }

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return prod;
    }
}