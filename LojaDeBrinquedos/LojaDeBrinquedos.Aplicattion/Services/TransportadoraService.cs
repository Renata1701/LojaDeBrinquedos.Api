using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class TransportadoraService : ITransportadoraService
{
    private readonly string _connectionString;
    private readonly List<Transportadora> _transportadoras;

    public TransportadoraService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL") ?? string.Empty;
        _transportadoras = new List<Transportadora>();
    }

    public void AdicionarTransportadora(Transportadora transportadora)
    {
        if (transportadora == null)
            throw new ArgumentNullException(nameof(transportadora));

        if (_transportadoras.Any(t => t.Id == transportadora.Id))
            throw new InvalidOperationException("Transportadora já existe.");

        _transportadoras.Add(transportadora);
    }

    public IEnumerable<Transportadora> ObterTodasTransportadoras()
    {
        return _transportadoras;
    }

    public Transportadora? ObterTransportadoraPorId(int id)
    {
        return _transportadoras.FirstOrDefault(t => t.Id == id);
    }

    public void AtualizarTransportadora(Transportadora transportadora)
    {
        var existente = ObterTransportadoraPorId(transportadora.Id);
        if (existente == null)
            throw new InvalidOperationException("Transportadora não encontrada.");

        existente.Nome = transportadora.Nome;
        existente.Telefone = transportadora.Telefone;
        existente.Email = transportadora.Email;
    }

    public void RemoverTransportadora(int id)
    {
        var transportadora = ObterTransportadoraPorId(id);
        if (transportadora == null)
            throw new InvalidOperationException("Transportadora não encontrada.");

        _transportadoras.Remove(transportadora);
    }

    IEnumerable<ITransportadoraService> ITransportadoraService.ObterTodasTransportadoras()
    {
        throw new NotImplementedException();
    }

    ITransportadoraService? ITransportadoraService.ObterTransportadoraPorId(int id)
    {
        throw new NotImplementedException();
    }

    void ITransportadoraService.AdicionarTransportadora(ITransportadoraService transportadora)
    {
        throw new NotImplementedException();
    }

    void ITransportadoraService.AtualizarTransportadora(ITransportadoraService transportadora)
    {
        throw new NotImplementedException();
    }
}