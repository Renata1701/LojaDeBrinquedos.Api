using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class NewLestterService(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");

    public async Task<List<NewsLetter>> ListarAsync()
    {
        var newsletters = new List<NewsLetter>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Email FROM NewsLetter";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar newsletters.", ex);
        }

        return newsletters;
    }

    public async Task<bool> AdicionarAsync(NewsLetter newsletter)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO NewsLetter (Email) VALUES (@Email)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Email", newsletter.Email);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
