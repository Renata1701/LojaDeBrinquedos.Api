using LojaDeBrinquedos.API.Services;
using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;
public interface ICupomDeDescontoService
{
    IEnumerable<CupomDeDescontoService> ObterTodosCupons();
    CupomDeDescontoService ObterCupomPorId(int id);
    void AdicionarCupons(CupomDeDescontoService cupomDeDesconto);
    void AtualizarCupom(CupomDeDescontoService cupomDeDesconto);
    void RemoverCupom(int id);
}
