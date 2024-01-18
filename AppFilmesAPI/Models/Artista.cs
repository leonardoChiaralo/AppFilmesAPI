using System.ComponentModel.DataAnnotations;

namespace AppFilmesAPI.Models;

public class Artista
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do artísta é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento do artísta é obrigatória.")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required]
    public int Idade => CalcularIdade();


    private int CalcularIdade()
    {
        DateTime dataAtual = DateTime.Now;
        int idade = dataAtual.Year - DataNascimento.Year;
        if (dataAtual.Month < DataNascimento.Month || (dataAtual.Month == DataNascimento.Month && dataAtual.Day < DataNascimento.Day))
        {
            idade--;
        }
        
        return idade;
    }
}
