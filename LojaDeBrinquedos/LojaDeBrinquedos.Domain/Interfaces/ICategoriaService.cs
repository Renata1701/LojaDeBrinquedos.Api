using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Interfaces;
public interface ICategoriaService
{
    IEnumerable<Categoria> ListarCategoria();
    Categoria BuscarPorId(Guid id);
    void Criar(Categoria categoria);
    void Atualizar(Categoria categoria);
    void Excluir(Guid id);
}

