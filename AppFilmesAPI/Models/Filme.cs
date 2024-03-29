﻿namespace AppFilmesAPI.Models;

public class Filme
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Ano { get; set; }
    public string? Genero { get; set; }
    public string? Diretor { get; set; }
    public int Duracao { get; set; }
    public double Nota { get; set; }
}
