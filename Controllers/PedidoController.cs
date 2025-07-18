using LojaDeBrinquedos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private static List<Pedido> pedidos = new();
    private readonly string _connectionString = "Server=Natalli_i5;Database=LojaDeBrinquedos;Trusted_Connection=True;\r\n";

    [HttpGet]
    public IActionResult Get()
    {
        var pedidos = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, ClienteId, DataPedido FROM Pedido";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            pedidos.Add(new
            {
                Id = reader.GetInt32(0),
                ClienteId = reader.GetInt32(1),
                DataPedido = reader.GetDateTime(2)
            });
        }

        return Ok(pedidos);
    }


    [HttpGet("{id}")]
    public ActionResult<Pedido> Get(int id)
    {
        var pedido = pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public ActionResult<Pedido> Post([FromBody] Pedido pedido)
    {
        pedido.Id = pedidos.Count > 0 ? pedidos.Max(p => p.Id) + 1 : 1;
        pedido.DataPedido = DateTime.Now;
        pedidos.Add(pedido);
        return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Pedido atualizado)
    {
        var pedido = pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound();

        pedido.ClienteId = atualizado.ClienteId;
        pedido.Status = atualizado.Status;
        pedido.ValorTotal = atualizado.ValorTotal;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pedido = pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null) return NotFound();

        pedidos.Remove(pedido);
        return NoContent();
    }
}