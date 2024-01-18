using AppFilmesAPI.Data;
using AppFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistaController : ControllerBase
{
    private ArtistaContext _context;

    public ArtistaController(ArtistaContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RegistrarArtista([FromBody] Artista artista)
    {
        _context.Artistas.Add(artista);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirArtistaPorId), new { id = artista.Id }, artista);
    }

    [HttpGet]
    public IEnumerable<Artista> ExibirArtistas()
    {
        return _context.Artistas;
    }

    [HttpGet("paginados")]
    public IEnumerable<Artista> ExibirArtistasPaginados([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Artistas.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ExibirArtistaPorId(int id)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);
        if (artista == null) return NotFound();
        return Ok(artista);
    }

    [HttpGet("nome/{nome}")]
    public IActionResult ExibirArtistaPorNome(string nome)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Nome == nome);
        if (artista == null) return NotFound();
        return Ok(artista);
    }
}
