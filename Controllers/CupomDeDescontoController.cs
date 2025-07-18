using LojaDeBrinquedos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CupomDeDescontoController : ControllerBase
{
    private static List<CupomDeDesconto> cupons = new();
    private readonly string _connectionString = "Server=Natalli_i5;Database=LojaDeBrinquedos;Trusted_Connection=True;\r\n";

    [HttpGet]
    public IActionResult Get()
    {
        var cupons = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Codigo, DescontoPercentual, ValidoAte FROM CupomDesconto";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            cupons.Add(new
            {
                Id = reader.GetInt32(0),
                Codigo = reader.GetString(1),
                DescontoPercentual = reader.GetDecimal(2),
                ValidoAte = reader.GetDateTime(3)
            });
        }

        return Ok(cupons);
    }



    [HttpGet("{id}")]
    public ActionResult<CupomDeDesconto> Get(int id)
    {
        var cupom = cupons.FirstOrDefault(c => c.Id == id);
        if (cupom == null) return NotFound();
        return Ok(cupom);
    }

    [HttpPost]
    public ActionResult<CupomDeDesconto> Post([FromBody] CupomDeDesconto cupom)
    {
        cupom.Id = cupons.Count > 0 ? cupons.Max(c => c.Id) + 1 : 1;
        cupons.Add(cupom);
        return CreatedAtAction(nameof(Get), new { id = cupom.Id }, cupom);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CupomDeDesconto atualizado)
    {
        var cupom = cupons.FirstOrDefault(c => c.Id == id);
        if (cupom == null) return NotFound();

        cupom.Codigo = atualizado.Codigo;
        cupom.ValorDesconto = atualizado.ValorDesconto;
        cupom.DataValidade = atualizado.DataValidade;
        cupom.Ativo = atualizado.Ativo;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cupom = cupons.FirstOrDefault(c => c.Id == id);
        if (cupom == null) return NotFound();

        cupons.Remove(cupom);
        return NoContent();
    }
}