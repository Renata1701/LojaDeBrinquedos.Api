using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class ItensCompradosService
{
    private readonly string _connectionString;

    public ItensCompradosService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<ItensComprados>> ListarAsync()
    {
        var itens = new List<ItensComprados>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, PedidoId, ProdutoId, Quantidade, PrecoUnitario FROM ItensComprados";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar itens comprados.", ex);
        }

        return itens;
    }

    public async Task<bool> AdicionarAsync(ItensComprados item)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = @"INSERT INTO ItensComprados (PedidoId, ProdutoId, Quantidade, PrecoUnitario)
                              VALUES (@PedidoId, @ProdutoId, @Quantidade, @PrecoUnitario)";

            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@PedidoId", item.PedidoId);
            comando.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
            comando.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            comando.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

