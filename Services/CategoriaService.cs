using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class CategoriaService(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");

    public async Task<List<Cliente>> ListarAsync()
    {
        var clientes = new List<Cliente>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Nome, Email, Telefone FROM Cliente";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
         
            throw new Exception("Erro ao listar clientes.", ex);
        }

        return clientes;
    }

    public async Task<bool> AdicionarAsync(Cliente cliente)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO Cliente (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Nome", cliente.Nome);
            comando.Parameters.AddWithValue("@Email", cliente.Email);
            comando.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception ex)
        { 
        
        
            return false;
        }
    }
}

