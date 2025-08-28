using LojaDeBrinquedos.Domain.Entities;
using LojaDeBrinquedos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class CategoriaService : ICategoriaService
{
    private readonly string _connectionString;
    private readonly List<Categoria> _categorias;

    public CategoriaService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL") ?? string.Empty;
        _categorias = new List<Categoria>();
    }

    public IEnumerable<Categoria> ListarCategoria()
    {
        return _categorias;
    }

    public Categoria BuscarPorId(Guid id)
    {
        return _categorias.FirstOrDefault(c => c.Id == id) ?? new Categoria();
    }

    public bool Criar(Categoria categoria)
    {
        try
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));
            if (_categorias.Any(c => c.Id == categoria.Id)) throw new InvalidOperationException("Categoria já existe.");
            categoria.Id = Guid.NewGuid();
            _categorias.Add(categoria);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Atualizar(Categoria categoria)
    {
        if (categoria == null) throw new ArgumentNullException(nameof(categoria));
        var existente = BuscarPorId(categoria.Id);
        if (existente == null || existente.Id == Guid.Empty) throw new InvalidOperationException("Categoria não encontrada.");
        
        var index = _categorias.FindIndex(c => c.Id == categoria.Id);
        if (index != -1)
        {
            _categorias[index] = categoria;
        }
    }

    public void Excluir(Guid id)
    {
        var categoria = BuscarPorId(id);
        if (categoria == null || categoria.Id == Guid.Empty) throw new InvalidOperationException("Categoria não encontrada.");
        _categorias.Remove(categoria);
    }
}