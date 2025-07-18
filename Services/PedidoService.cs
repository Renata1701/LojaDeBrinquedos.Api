using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class PedidoService
{
    private readonly string _connectionString;

    public PedidoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<Pedido>> ListarAsync()
    {
        var pedidos = new List<Pedido>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, ClienteId, DataPedido, Status FROM Pedido";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar pedidos.", ex);
        }

        return pedidos;
    }

    public async Task<bool> AdicionarAsync(Pedido pedido)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO Pedido (ClienteId, DataPedido, Status) VALUES (@ClienteId, @DataPedido, @Status)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@ClienteId", pedido.ClienteId);
            comando.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
            comando.Parameters.AddWithValue("@Status", pedido.Status);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

