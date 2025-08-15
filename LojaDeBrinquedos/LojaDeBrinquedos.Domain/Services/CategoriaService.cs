using LojaDeBrinquedos.Domain.Entities;
using LojaDeBrinquedos.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class CategoriaService : ICategoriaService
{
    public readonly string _connectionString = ConnectionString("MinhaConexaoSQL");

    private static string ConnectionString(string v)
    {
        throw new NotImplementedException();
    }

    private readonly List<Categoria> _categorias;

    public IEnumerable<Categoria> ListarCategorias()
    {
        return _categorias;
    }

    public Categoria BuscarPorId(Guid id)
    {
        return _categorias.FirstOrDefault(c => c.Id == id);
    }

    public void Criar(Categoria categoria)
    {
        if (categoria == null) throw new ArgumentNullException(nameof(categoria));
        if (_categorias.Any(c => c.Id == categoria.Id)) throw new InvalidOperationException("Categoria já existe.");
        categoria.Id = Guid.NewGuid();
        _categorias.Add(categoria);
    }

    public void Atualizar(Categoria categoria)
    {
        if (categoria == null) throw new ArgumentNullException(nameof(categoria));
        var existente = BuscarPorId(categoria.Id);
        if (existente == null) throw new InvalidOperationException("Categoria não encontrada.");

        
    }

    private object BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void Excluir(Guid id)
    {
        var categoria = BuscarPorId(id);
        if (categoria == null) throw new InvalidOperationException("Categoria não encontrada.");
        _categorias.Remove(categoria);
    }

    // Assíncronos
    public Task<IEnumerable<Categoria>> ListarCategoriasAsync()
    {
        return Task.Run(() => (IEnumerable<Categoria>)_categorias);
    }

    public Task<Categoria> BuscarPorIdAsync(Guid id)
    {
        return Task.Run(() => BuscarPorId(id));
    }

    public Task<Categoria> CriarAsync(Categoria categoria)
    {
        return Task.Run(() =>
        {
            Criar(categoria);
            return categoria;
        });
    }

    public Task<Categoria> AtualizarAsync(Categoria categoria)
    {
        return Task.Run(() =>
        {
            Atualizar(categoria);
            return categoria;
        });
    }

    public Task<bool> ExcluirAsync(Guid id)
    {
        return Task.Run(() =>
        {
            Excluir(id);
            return true;
        });
    }

    public IEnumerable<Categoria> ListarCategoria()
    {
        throw new NotImplementedException();
    }
}