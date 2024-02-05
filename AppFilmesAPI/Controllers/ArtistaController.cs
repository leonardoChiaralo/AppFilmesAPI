using AppFilmesAPI.Data;
using AppFilmesAPI.Data.DTOs.Artista;
using AppFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistaController : ControllerBase
{
    private AppFilmesContext _context;

    public ArtistaController(AppFilmesContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RegistrarArtista([FromBody] CreateArtistaDTO artistaDTO)
    {
        Artista artista = new Artista
        {
            Nome = artistaDTO.Nome,
            DataNascimento = artistaDTO.DataNascimento,
        };
        _context.Artistas.Add(artista);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirArtistaPorId), new {id =  artista.Id}, artista);
    }

    [HttpGet]
    public IEnumerable<ReadArtistaDTO> ExibirArtistas()
    {
        var artistas = _context.Artistas.ToList();
        var readArtistas = artistas.Select(artista => new ReadArtistaDTO
        {
            Nome = artista.Nome,
            DataNascimento = artista.DataNascimento,
            Idade = artista.Idade,
        }).ToList();
        return readArtistas;
    }

    [HttpGet("paginados")]
    public IEnumerable<ReadArtistaDTO> ExibirArtistasPaginados([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var artistas = _context.Artistas.ToList();
        var readArtistas = artistas.Select(artista => new ReadArtistaDTO
        {
            Nome = artista.Nome,
            DataNascimento = artista.DataNascimento,
            Idade = artista.Idade,
        }).ToList();
        return readArtistas.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ExibirArtistaPorId(int id)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);
        if (artista == null) return NotFound();
        var readArtista = new ReadArtistaDTO
        {
            Nome = artista.Nome,
            DataNascimento = artista.DataNascimento,
            Idade = artista.Idade,
        };
        return Ok(readArtista);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarArtista(int id, [FromBody] UpdateArtistaDTO artistaDTO)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);
        if (artista == null) return NotFound();
        artista.Nome = artistaDTO.Nome;
        artista.DataNascimento = artistaDTO.DataNascimento;
        artista.Idade = artistaDTO.Idade;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarArtista(int id)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);
        if (artista == null) return NotFound();
        _context.Artistas.Remove(artista);
        _context.SaveChanges();
        return NoContent();
    }
}
