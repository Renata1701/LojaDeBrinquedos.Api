using LojaDeBrinquedos.Aplicattion.Interfaces;
using Microsoft.Data.SqlClient;
using static LojaDeBrinquedos.API.Services.PedidoService;

namespace LojaDeBrinquedos.API.Services;

public class CupomDeDescontoService : ICupomDeDescontoService
{
    private readonly string _connectionString;
    private object Codigo;
    private object ValorDesconto;
    private object DataValidade;
    private List<ICupomDeDescontoService> Cupom;

    public CupomDeDescontoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<ICupomDeDescontoService>> ListarAsync()
    {
        var CupomDeDescontoService = new List<CupomDeDescontoService>();

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

        return Cupom;
    }

    public async Task<bool> AdicionarAsync(CupomDeDescontoService cupom)
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

    public IEnumerable<CupomDeDescontoService> ObterTodosCupons()
    {
        throw new NotImplementedException();
    }

    public CupomDeDescontoService ObterCupomPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void AdicionarCupons(CupomDeDescontoService cupomDeDesconto)
    {
        throw new NotImplementedException();
    }

    public void AtualizarCupom(CupomDeDescontoService cupomDeDesconto)
    {
        throw new NotImplementedException();
    }

    public void RemoverCupom(int id)
    {
        throw new NotImplementedException();
    }
}
