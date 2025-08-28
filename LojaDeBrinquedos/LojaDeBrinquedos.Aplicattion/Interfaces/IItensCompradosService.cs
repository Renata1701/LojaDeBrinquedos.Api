using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;
public interface IItensCompradosService
{
    IEnumerable<ItensComprados> ObterTodosItensComprados();
    void AdicionarItensComprados(ItensComprados itensComprados);
    void AtualizarItensComprados(ItensComprados itensComprados);
    void RemoverItensComprados(int id);
}
