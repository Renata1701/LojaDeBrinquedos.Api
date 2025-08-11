using LojaDeBrinquedos.API.Domain.Entities;
using LojaDeBrinquedos.API.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class ProdutoService(IConfiguration configuration) : IProdutoService
{
    private List<Produto> _values = new List<Produto>();
    public string? _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");

    public void Add(Produto produto)
    {
        _values.Add(produto);
    }

    public List<Produto> GetAll()
    {
        return _values;
    }

    public Produto GetById(int id)
    {
        return _values.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Produto produto)
    {
        var existingProduto = GetById(produto.Id);
        if (existingProduto != null)
        {
            existingProduto.Nome = produto.Nome;
            existingProduto.Preco = produto.Preco;
            existingProduto.Descricao = produto.Descricao;
        }
    }

    public void Delete(int id)
    {
        var produto = GetById(id);
        if (produto != null)
        {
            _values.Remove(produto);
        }
    }

    public void Clear()
    {
        _values.Clear();
    }

    public bool Exists(int id)
    {
        return _values.Any(x => x.Id == id);
    }

    public List<Produto> SearchByName(string name)
    {
        return _values.Where(x => x.Nome.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Produto> SearchByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _values.Where(x => x.Preco >= minPrice && x.Preco <= maxPrice).ToList();
    }

    public Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Produto> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Produto> AdicionarAsync(Produto produto)
    {
        throw new NotImplementedException();
    }

    public Task<Produto> AtualizarAsync(Produto produto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }
}
