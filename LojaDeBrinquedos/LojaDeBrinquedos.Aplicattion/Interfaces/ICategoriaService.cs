using LojaDeBrinquedos.Domain.Entities;

namespace LojaDeBrinquedos.Domain.Interfaces;
public interface ICategoriaService
{
    IEnumerable<Categoria> ListarCategoria();
    Categoria BuscarPorId(Guid id);
    bool Criar(Categoria categoria);
    void Atualizar(Categoria categoria);
    void Excluir(Guid id);
}

