using Microsoft.AspNetCore.Mvc.Routing;
using MySqlConnector;
using Products.Models;

namespace Products;

public class Connect {
    static string dbUrl = Environment.GetEnvironmentVariable("DB_URL");
    static string dbUser = Environment.GetEnvironmentVariable("DB_USER");
    static string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
    static string dbName = Environment.GetEnvironmentVariable("DB_NAME");

    public static async Task<Product?> Insert(Product prod) {
        try {
            var connection = new MySqlConnection(String.Format("Server={0};User ID={1};Password={2};Database={3}", dbUrl, dbUser, dbPassword, dbName));
            await connection.OpenAsync();

            var queryInsert = new MySqlCommand("INSERT INTO Products (category, name, price, description, pic_url) VALUES (@c, @n, @p, @d, @u)", connection);
            queryInsert.Parameters.AddWithValue("c", prod.Category);
            queryInsert.Parameters.AddWithValue("n", prod.Name);
            queryInsert.Parameters.AddWithValue("p", prod.Price);
            queryInsert.Parameters.AddWithValue("d", prod.Description);
            queryInsert.Parameters.AddWithValue("u", prod.PicUrl);

            await queryInsert.ExecuteNonQueryAsync();

            connection.Close();

            await connection.OpenAsync();

            var querySelectOne = new MySqlCommand("SELECT ID FROM Products WHERE name = (@n)", connection);
            querySelectOne.Parameters.AddWithValue("n", prod.Name);

            var reader = await querySelectOne.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod.Id = reader.GetInt16(0);
            }

        } catch (Exception e) {
            Console.WriteLine(e);
            return null;
        }

        return prod;
    }

    public static async Task<Product?> GetOne(int id) {
        Product? prod = null;

        try {
            var connection = new MySqlConnection(String.Format("Server={0};User ID={1};Password={2};Database={3}", dbUrl, dbUser, dbPassword, dbName));
            await connection.OpenAsync();

            var querySelectOne = new MySqlCommand("SELECT * FROM Products WHERE ID = (@p)", connection);
            querySelectOne.Parameters.AddWithValue("p", id);

            var reader = await querySelectOne.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new Product(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
            }

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return prod;
    }

    public static async Task<List<Product>> GetAll() {
        List<Product> products = new();

        try {
            var connection = new MySqlConnection(String.Format("Server={0};User ID={1};Password={2};Database={3}", dbUrl, dbUser, dbPassword, dbName));
            await connection.OpenAsync();

            var querySelect = new MySqlCommand("SELECT * FROM Products", connection);
            var reader = await querySelect.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                Product prod = new Product(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
                products.Add(prod);
            }

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return products;
    }

    public static async Task<Product?> DeleteOne(int id) {
        Product? prod = null; 

        try {
            var connection = new MySqlConnection(String.Format("Server={0};User ID={1};Password={2};Database={3}", dbUrl, dbUser, dbPassword, dbName));
            await connection.OpenAsync();

            var querySelectOne = new MySqlCommand("SELECT * FROM Products WHERE ID = (@p)", connection);
            querySelectOne.Parameters.AddWithValue("p", id);

            var reader = await querySelectOne.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
                prod.Id = reader.GetInt16(0);
            }

            connection.Close();

            if (prod == null) {
                return prod;
            }

            await connection.OpenAsync();

            var queryDelete = new MySqlCommand("DELETE FROM Products WHERE ID = (@p)", connection);
            queryDelete.Parameters.AddWithValue("p", id);

            await queryDelete.ExecuteNonQueryAsync();

            connection.Close();
        } catch (Exception e) {
            Console.WriteLine(e);
        }

        return prod;
    }

    public static async Task<Product?> UpdateField(int id, string field, string val) {
        Product? prod = null; 

        try {
            var connection = new MySqlConnection(String.Format("Server={0};User ID={1};Password={2};Database={3}", dbUrl, dbUser, dbPassword, dbName));
            await connection.OpenAsync();

            var querySelectOne = new MySqlCommand("SELECT * FROM Products WHERE ID = (@p)", connection);
            querySelectOne.Parameters.AddWithValue("p", id);

            var reader = await querySelectOne.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
            }

            connection.Close();

            if (prod == null) {
                return null;
            }

            await connection.OpenAsync();

            var queryUpdate = new MySqlCommand("UPDATE Products SET " + field + " = @v WHERE ID = @p", connection);
            queryUpdate.Parameters.AddWithValue("p", id);
            queryUpdate.Parameters.AddWithValue("v", field != "price" ? val : float.Parse(val));

            await queryUpdate.ExecuteNonQueryAsync();

            connection.Close();

            await connection.OpenAsync();

            reader = await querySelectOne.ExecuteReaderAsync();
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

    public static async Task<Product?> UpdateProduct(int id, Product product) {
        Product? prod = null; 

        try {
            var connection = new MySqlConnection(String.Format("Server={0};User ID={1};Password={2};Database={3}", dbUrl, dbUser, dbPassword, dbName));
            await connection.OpenAsync();

            var querySelectOne = new MySqlCommand("SELECT * FROM Products WHERE ID = (@p)", connection);
            querySelectOne.Parameters.AddWithValue("p", id);

            var reader = await querySelectOne.ExecuteReaderAsync();

            while (await reader.ReadAsync()) {
                prod = new(reader.GetString(1), reader.GetString(2), reader.GetFloat(3), reader.GetString(4), reader.GetString(5));
            }

            connection.Close();

            if (prod == null) {
                return null;
            }

            await connection.OpenAsync();

            var queryUpdate = new MySqlCommand("UPDATE Products SET category = @c, name = @n, description = @d, price = @p, pic_url = @u WHERE ID = @i", connection);
            queryUpdate.Parameters.AddWithValue("i", id);
            queryUpdate.Parameters.AddWithValue("c", product.Category);
            queryUpdate.Parameters.AddWithValue("n", product.Name);
            queryUpdate.Parameters.AddWithValue("d", product.Description);
            queryUpdate.Parameters.AddWithValue("p", product.Price);
            queryUpdate.Parameters.AddWithValue("u", product.PicUrl);

            await queryUpdate.ExecuteNonQueryAsync();

            connection.Close();

            await connection.OpenAsync();

            reader = await querySelectOne.ExecuteReaderAsync();
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
