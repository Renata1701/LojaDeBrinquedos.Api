using LojaDeBrinquedos.API.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class CupomDeDescontoService
{
    private readonly string _connectionString;

    public CupomDeDescontoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<CupomDeDesconto>> ListarAsync()
    {
        var cupons = new List<CupomDeDesconto>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Codigo, Desconto, Validade FROM CupomDeDesconto";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();
            
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar cupons de desconto.", ex);
        }

        return cupons;
    }

    public async Task<bool> AdicionarAsync(CupomDeDesconto cupom)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO CupomDeDesconto (Codigo, Desconto, Validade) VALUES (@Codigo, @Desconto, @Validade)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Codigo", cupom.Codigo);
            comando.Parameters.AddWithValue("@Desconto", cupom.ValorDesconto);
            comando.Parameters.AddWithValue("@Validade", cupom.DataValidade);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
