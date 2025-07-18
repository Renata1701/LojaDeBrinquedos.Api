using LojaDeBrinquedos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntregaController : ControllerBase
{
    private static List<Entrega> entregas = new();

    private readonly string _connectionString = "Server=Natalli_i5;Database=LojaDeBrinquedos;Trusted_Connection=True;\r\n";

    [HttpGet]
    public IActionResult Get()
    {
        var entregas = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, PedidoId, TransportadoraId, Status FROM Entrega";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            entregas.Add(new
            {
                Id = reader.GetInt32(0),
                PedidoId = reader.GetInt32(1),
                TransportadoraId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                Status = reader.GetString(3)
            });
        }

        return Ok(entregas);
    }


    [HttpGet("{id}")]
    public ActionResult<Entrega> Get(int id)
    {
        var entrega = entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null) return NotFound();
        return Ok(entrega);
    }

    [HttpPost]
    public ActionResult<Entrega> Post([FromBody] Entrega entrega)
    {
        entrega.Id = entregas.Count > 0 ? entregas.Max(e => e.Id) + 1 : 1;
        entregas.Add(entrega);
        return CreatedAtAction(nameof(Get), new { id = entrega.Id }, entrega);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Entrega atualizada)
    {
        var entrega = entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null) return NotFound();

        entrega.PedidoId = atualizada.PedidoId;
        entrega.DataEntrega = atualizada.DataEntrega;
        entrega.Status = atualizada.Status;
        entrega.EnderecoEntrega = atualizada.EnderecoEntrega;
        entrega.Transportadora = atualizada.Transportadora;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entrega = entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null) return NotFound();

        entregas.Remove(entrega);
        return NoContent();
    }
}

