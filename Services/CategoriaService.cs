using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class CategoriaService
{
    private readonly List<Categoria> _categorias = new();

    public List<Categoria> Listar() => _categorias;

    public void Adicionar(Categoria categoria) => _categorias.Add(categoria);

    public Categoria BuscarPorId(int id) => _categorias.FirstOrDefault(c => c.Id == id);
}


