using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;
public interface IFornecedorService
{
    IEnumerable<Fornecedor> ObterTodosFornecedor();
    Fornecedor ObterFornecedorPorId(int id);
    void AdicionarCliente(Cliente cliente);
    void AtualizarCliente(Cliente cliente);
    void RemoverCliente(int id);
}
