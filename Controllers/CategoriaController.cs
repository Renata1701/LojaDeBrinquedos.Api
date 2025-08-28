using LojaDeBrinquedos.API.ResultModel;
using LojaDeBrinquedos.Domain.Entities;
using LojaDeBrinquedos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private string? _connectionString;
    private readonly IConfiguration _configuration;
    private readonly ICategoriaService _categoriaService;


    public CategoriaController(IConfiguration configuration, ICategoriaService categoriaService)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
        _categoriaService = categoriaService;
    }

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
    public ActionResult<CategoriaResult> GetCategoria(Guid id)
    {
        var categoria = _categoriaService.BuscarPorId(id);

        if (categoria.Id != id)
        {
            return NotFound();
        }
        return Ok(new CategoriaResult(categoria.Nome, categoria.Descricao));
    }

    [HttpPost]
    public ActionResult<bool> CreateCategoria(Categoria categoria)
    {
        var result = _categoriaService.Criar(categoria);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public ActionResult<CategoriaResult> UpdateOrCreateCategoria(Guid id, Categoria categoria)
    {
        var categoriaAtualizada = _categoriaService.BuscarPorId(categoria.Id);
        if (id != categoriaAtualizada.Id)
        {
            _categoriaService.Criar(categoria);
            return BadRequest();
        }
        _categoriaService.Atualizar(categoria);

        return Ok(new CategoriaResult(categoria.Nome, categoria.Descricao));
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