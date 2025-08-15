using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Entities;
public class Categoria
{
    public Guid Id { get; set; }   
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public Categoria(int id, string nome, string descricao, Guid Id)
    {
        _ = id;
        Nome = nome;
        Descricao = descricao;
    }
}
