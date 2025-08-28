using LojaDeBrinquedos.API.Services;
using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;
public interface INewsLetterService
{
    IEnumerable<INewsLetterService> ObterTodosNewsLetter();
    INewsLetterService ObterNewsLetterPorId(int id);
    void AdicionarNewsLetter(NewLestterService newLestterService);
    void AtualizarNewsLetter(INewsLetterService newsLetterService);
    void RemoverNewsLetter(int id);
}
