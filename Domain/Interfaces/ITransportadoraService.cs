using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface ITransportadoraService
{
    void AdicionarTransportadora(Transportadora transportadora);
    IEnumerable<Transportadora> ObterTodasTransportadoras();
    Transportadora ObterTransportadoraPorId(int id);
    void AtualizarTransportadora(Transportadora transportadora);
    void RemoverTransportadora(int id);
}
