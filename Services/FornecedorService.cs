using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class FornecedorService
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

            while (await leitor.ReadAsync())
            {
                fornecedores.Add(new Fornecedor
                {
                    Id = leitor.GetInt32(0),
                    Nome = leitor.GetString(1),
                    Telefone = leitor.GetString(2),
                    Email = leitor.GetString(3)
                });
            }
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

}
