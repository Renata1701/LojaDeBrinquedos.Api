using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NewsLetterController : ControllerBase
{
    private static List<NewsLetter> assinaturas = new();
    private string? _connectionString;

    public NewsLetterController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var newsletters = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Email, DataCadastro FROM Newsletter";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            newsletters.Add(new
            {
                Id = reader.GetInt32(0),
                Email = reader.GetString(1),
                DataCadastro = reader.GetDateTime(2)
            });
        }

        return Ok(newsletters);
    }


    [HttpPost]
    public ActionResult<NewsLetter> Post([FromBody] NewsLetter newsletter)
    {
        newsletter.Id = assinaturas.Count > 0 ? assinaturas.Max(n => n.Id) + 1 : 1;
        assinaturas.Add(newsletter);
        return CreatedAtAction(nameof(Get), new { id = newsletter.Id }, newsletter);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] NewsLetter newsletter)
    {
        var existente = assinaturas.FirstOrDefault(n => n.Id == id);
        if (existente == null) return NotFound();

        existente.Email = newsletter.Email;
        existente.Status = newsletter.Status;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = assinaturas.FirstOrDefault(n => n.Id == id);
        if (item == null) return NotFound();
        assinaturas.Remove(item);
        return NoContent();
    }
}
