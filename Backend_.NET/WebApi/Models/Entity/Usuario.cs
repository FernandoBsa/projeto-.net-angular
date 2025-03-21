﻿namespace WebApi.Models.Entity;

public class Usuario
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }
    public string CPF { get; set; }
    public bool Situacao { get; set; }
    public string Senha { get; set; }
}