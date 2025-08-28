using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;
public interface ITransportadoraService
{
    IEnumerable<ITransportadoraService> ObterTodasTransportadoras();
    ITransportadoraService ObterTransportadoraPorId(int id);
    void AdicionarTransportadora(ITransportadoraService transportadora);
    void AtualizarTransportadora(ITransportadoraService transportadora);
    void RemoverTransportadora(int id);

}
    



