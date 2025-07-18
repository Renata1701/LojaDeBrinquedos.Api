using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class PagamentoService
{
    private readonly string _connectionString;

    public PagamentoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public void RegistrarPagamento(Pagamento pagamento)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();

        string query = "INSERT INTO Pagamentos (PedidoId, Valor, DataPagamento, MetodoPagamento) " +
                       "VALUES (@PedidoId, @Valor, @DataPagamento, @MetodoPagamento)";

        using SqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@PedidoId", pagamento.PedidoId);
        command.Parameters.AddWithValue("@Valor", pagamento.Valor);
        command.Parameters.AddWithValue("@DataPagamento", pagamento.DataPagamento);


        command.ExecuteNonQuery();
    }


}


