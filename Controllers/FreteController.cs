using LojaDeBrinquedos.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FreteController : ControllerBase
{
    private static List<Frete> fretes = new();
    private string? _connectionString;

    public FreteController (IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }
    [HttpGet]
    public ActionResult<IEnumerable<Frete>> Get() => Ok(fretes);

    [HttpGet("{id}")]
    public ActionResult<Frete> Get(int id)
    {
        var frete = fretes.FirstOrDefault(f => f.Id == id);
        if (frete == null) return NotFound();
        return Ok(frete);
    }

    [HttpPost]
    public ActionResult<Frete> Post([FromBody] Frete frete)
    {
        frete.Id = fretes.Count > 0 ? fretes.Max(f => f.Id) + 1 : 1;
        fretes.Add(frete);
        return CreatedAtAction(nameof(Get), new { id = frete.Id }, frete);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Frete atualizado)
    {
        var frete = fretes.FirstOrDefault(f => f.Id == id);
        if (frete == null) return NotFound();

        frete.PedidoId = atualizado.PedidoId;
        frete.Valor = atualizado.Valor;
        frete.Tipo = atualizado.Tipo;
        frete.DataEnvio = atualizado.DataEnvio;
        frete.DataEntregaEstimada = atualizado.DataEntregaEstimada;
        frete.Status = atualizado.Status;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var frete = fretes.FirstOrDefault(f => f.Id == id);
        if (frete == null) return NotFound();

        fretes.Remove(frete);
        return NoContent();
    }
}

