using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class EntregaService
{
    private readonly string _connectionString;

    public EntregaService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<Entrega>> ListarAsync()
    {
        var entregas = new List<Entrega>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, PedidoId, DataEntrega, Status FROM Entrega";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar entregas.", ex);
        }

        return entregas;
    }

    public async Task<bool> AdicionarAsync(Entrega entrega)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO Entrega (PedidoId, DataEntrega, Status) VALUES (@PedidoId, @DataEntrega, @Status)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@PedidoId", entrega.PedidoId);
            comando.Parameters.AddWithValue("@DataEntrega", entrega.DataEntrega);
            comando.Parameters.AddWithValue("@Status", entrega.Status);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}


