using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class TransportadoraService
{
    private readonly string _connectionString;

    public TransportadoraService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<Transportadora>> ListarAsync()
    {
        var transportadoras = new List<Transportadora>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Nome, Telefone FROM Transportadora";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar transportadoras.", ex);
        }

        return transportadoras;
    }

    public async Task<bool> AdicionarAsync(Transportadora transportadora)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO Transportadora (Nome, Telefone) VALUES (@Nome, @Telefone)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Nome", transportadora.Nome);
            comando.Parameters.AddWithValue("@Telefone", transportadora.Telefone);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

