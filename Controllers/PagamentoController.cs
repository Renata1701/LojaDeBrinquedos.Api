using LojaDeBrinquedos.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PagamentoController : ControllerBase
{
    private static List<Pagamento> pagamentos = new();
    private string? _connectionString;

    public PagamentoController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var pagamentos = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        
        string query = "SELECT Id, PedidoId, Valor, DataPagamento, Metodo FROM Pagamento";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            pagamentos.Add(new
            {
                Id = reader.GetInt32(0),
                PedidoId = reader.GetInt32(1),
                Valor = reader.GetDecimal(2),
                DataPagamento = reader.GetDateTime(3),
                Metodo = reader.GetString(4)
            });
        }

        return Ok(pagamentos);
    }


    [HttpGet("{id}")]
    public ActionResult<Pagamento> Get(int id)
    {
        var pagamento = pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null) return NotFound();
        return Ok(pagamento);
    }

    [HttpPost]
    public ActionResult<Pagamento> Post([FromBody] Pagamento pagamento)
    {
        pagamento.Id = pagamentos.Count > 0 ? pagamentos.Max(p => p.Id) + 1 : 1;
        pagamentos.Add(pagamento);
        return CreatedAtAction(nameof(Get), new { id = pagamento.Id }, pagamento);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Pagamento atualizado)
    {
        var pagamento = pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null) return NotFound();

        pagamento.PedidoId = atualizado.PedidoId;
        pagamento.DataPagamento = atualizado.DataPagamento;
        pagamento.Metodo = atualizado.Metodo;
        pagamento.Status = atualizado.Status;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pagamento = pagamentos.FirstOrDefault(p => p.Id == id);
        if (pagamento == null) return NotFound();

        pagamentos.Remove(pagamento);
        return NoContent();
    }
}

