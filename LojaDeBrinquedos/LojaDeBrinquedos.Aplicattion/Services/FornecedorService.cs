using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using Microsoft.Data.SqlClient;
using static LojaDeBrinquedos.API.Services.PedidoService;

namespace LojaDeBrinquedos.API.Services;

public class FornecedorService : IFornecedorService
{

    private readonly string _connectionString;

    public FornecedorService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<Fornecedor>> ListarAsync()
    {
        var fornecedores = new List<Fornecedor>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Nome, Telefone, Email FROM Fornecedor";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar fornecedores.", ex);
        }

        return fornecedores;
    }

    public async Task<bool> AdicionarAsync(Fornecedor fornecedor)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO Fornecedor (Nome, Telefone, Email) VALUES (@Nome, @Telefone, @Email)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Nome", fornecedor.Nome);
            comando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
            comando.Parameters.AddWithValue("@Email", fornecedor.Email);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<Fornecedor> ObterTodosFornecedor()
    {
        throw new NotImplementedException();
    }

    public Fornecedor ObterFornecedorPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void AdicionarCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void AtualizarCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void RemoverCliente(int id)
    {
        throw new NotImplementedException();
    }
}
