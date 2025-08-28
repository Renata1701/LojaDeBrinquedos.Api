using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;
public interface IFuncionariosService
{
    IEnumerable<Funcionarios> ObterTodosFuncionarios();
    IFuncionariosService ObterFuncionariosPorId(int id);
    void AdicionarFuncionarios(Funcionarios funcionarios);
    void AtualizarFuncionarios(Funcionarios funcionarios);
    void RemoverFuncionarios(int id);
}
