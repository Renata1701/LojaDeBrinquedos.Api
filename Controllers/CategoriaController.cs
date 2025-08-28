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

        if (string.IsNullOrEmpty(_connectionString))
        {
            // Retorna dados mock se não houver conexão
            return Ok(new List<object>
            {
                new { Id = 1, Nome = "Brinquedos Educativos" },
                new { Id = 2, Nome = "Brinquedos Eletrônicos" },
                new { Id = 3, Nome = "Brinquedos de Montar" }
            });
        }

        try
        {
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
        }
        catch (Exception ex)
        {
            // Retorna dados mock em caso de erro
            return Ok(new List<object>
            {
                new { Id = 1, Nome = "Brinquedos Educativos" },
                new { Id = 2, Nome = "Brinquedos Eletrônicos" },
                new { Id = 3, Nome = "Brinquedos de Montar" }
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
        return Ok(new CategoriaResult 
        { 
            Nome = categoria.Nome, 
            Descricao = categoria.Descricao 
        });
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

        return Ok(new CategoriaResult 
        { 
            Nome = categoria.Nome, 
            Descricao = categoria.Descricao 
        });
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
