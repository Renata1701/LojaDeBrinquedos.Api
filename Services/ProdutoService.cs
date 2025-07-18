using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class ProdutoService
{
    private readonly string _connectionString;

    public ProdutoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public List<Dictionary<string, object>> ListarProdutos()
    {
        var produtos = new List<Dictionary<string, object>>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string query = "SELECT Id, Nome, Quantidade, Preco FROM Produto";

            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new Dictionary<string, object>
                    {
                        { "Id", reader.GetInt32(0) },
                        { "Nome", reader.GetString(1) },
                        { "Quantidade", reader.GetInt32(2) },
                        { "Preco", reader.GetDecimal(3) }
                    };

                    produtos.Add(item);
                }
            }
        }

        return produtos;
    }
}
