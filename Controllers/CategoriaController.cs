using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly string _connectionString = "Server=Natalli_i5;Database=LojaDeBrinquedos;Trusted_Connection=True;";

    [HttpGet]
    public IActionResult Get()
    {
        var categorias = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nome FROM Categoria";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            categorias.Add(new
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            });
        }

        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public ActionResult<Models.CategoriaService> GetCategoria(int id)
    {
        var categoria = new Models.CategoriaService(1, "Brinquedos de Construção");

        if (categoria.Id != id)
        {
            return NotFound();
        }

        return Ok(categoria);
    }
    [HttpPost]
    public ActionResult<Models.CategoriaService> CreateCategoria(Models.CategoriaService categoria)
    {
        categoria.Id = 4;
        return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateCategoria(int id, Models.CategoriaService categoriaAtualizada)
    {
        if (id != categoriaAtualizada.Id)
        {
            return BadRequest();
        }

        return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteCategoria(int id)
    {
        if (id <= 0)
        {
            return NotFound();
        }
        return NoContent();
    }
}