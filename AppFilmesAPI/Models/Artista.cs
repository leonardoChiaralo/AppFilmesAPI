using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFilmesAPI.Models;

public class Artista
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do artísta é obrigatório.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento do artísta é obrigatória.")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    public int Idade { get; set; }
}
