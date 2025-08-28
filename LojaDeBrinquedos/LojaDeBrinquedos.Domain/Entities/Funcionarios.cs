using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class Funcionarios
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public DateTime DataContratacao { get; set; }
    public DateTime DataAdmissao { get; set; } = DateTime.Now;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    
    // Construtor padrão
    public Funcionarios() { }
    
    public Funcionarios(int id, string nome, string cargo, decimal salario, DateTime dataContratacao)
    {
        Id = id;
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
        DataContratacao = dataContratacao;
    }
}
