using AppFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new();
    private static int id = 0;

    [HttpPost]
    public IActionResult RegistrarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(ExibirFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> ExibirFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public IActionResult ExibirFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpGet("titulo/{titulo}")]
    public IActionResult ExibirFilmePorTitulo(string titulo)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Titulo == titulo);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
