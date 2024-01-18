using AppFilmesAPI.Data;
using AppFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
   private FilmeContext _context;

    public FilmeController(FilmeContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RegistrarFilme([FromBody] Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> ExibirFilmes()
    {
        return _context.Filmes;
    }

    [HttpGet("paginados")]
    public IEnumerable<Filme> ExibirFilmesPaginados([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ExibirFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpGet("titulo/{titulo}")]
    public IActionResult ExibirFilmePorTitulo(string titulo)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Titulo == titulo);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
