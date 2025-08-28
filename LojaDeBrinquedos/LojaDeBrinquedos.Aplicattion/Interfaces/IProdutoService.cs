using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Interfaces;
public interface IProdutoService
{
    IEnumerable<Produto> ListarProdutos();
    Produto BuscarPorId(Guid id);
    void Criar(Produto produto);
    void Atualizar(Produto produto);
    void Excluir(Guid id);
}
