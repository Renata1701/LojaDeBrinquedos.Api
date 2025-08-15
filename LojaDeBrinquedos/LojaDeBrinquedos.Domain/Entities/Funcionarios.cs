using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Entities;
public class Funcionarios
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataContratacao { get; set; }
    public Funcionarios(int id, string nome, string cargo, decimal salario, DateTime dataContratacao)
    {
        Id = id;
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
        DataContratacao = dataContratacao;
    }
}
