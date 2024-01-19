﻿using System.ComponentModel.DataAnnotations;

namespace AppFilmesAPI.Data.DTOs;

public class CreateFilmeDTO
{
    [Required(ErrorMessage = "O título do filme é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O ano de lançamento é obrigatório.")]
    public string Ano { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O diretor do filme é obrigatório.")]
    public string Diretor { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatória.")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    public int Duracao { get; set; }

    [Range(0, 10, ErrorMessage = "A nota do filme precisa ser de 0 a 10.")]
    public double Nota { get; set; }
}