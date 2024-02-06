using AppFilmesAPI.Data;
using AppFilmesAPI.Data.DTOs.ArtistaFilme;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistaFilmeController : ControllerBase
{
    private AppFilmesContext _context;

    public ArtistaFilmeController(AppFilmesContext context)
    {
        _context = context;
    }

    [HttpPost("elenco")]
    public IActionResult AdicionarElenco([FromBody] CreateArtistaFilmeDTO artistaFilmeDTO)
    {
        var filme = _context.Filmes.Include(f => f.Elenco).FirstOrDefault(f => f.Id == artistaFilmeDTO.FilmeId);
        var artista = _context.Artistas.Find(artistaFilmeDTO.ArtistaId);
        filme!.Elenco.Add(artista!);
        _context.SaveChanges();
        return NoContent();
    }

    //[HttpGet("elenco/{id}")]
    //public IActionResult ExibirElenco(int id)
    //{
    //    var filme = _context.Filmes.Include(f => f.Elenco).FirstOrDefault(f => f.Id == id);
    //    List<string> artistas = new();

    //    foreach (var artista in filme!.Elenco)
    //    {
    //        artistas.Add(artista.Nome!);
    //    }

    //    return Ok(artistas);
    //}

    [HttpGet("elenco/{id}")]
    public IEnumerable<ReadElencoDTO> ExibirElenco(int id)
    {
        var filme = _context.Filmes.Include(filme => filme.Elenco).FirstOrDefault(filme => filme.Id == id);
        List<ReadElencoDTO> artistas = new();

        foreach (var artista in filme!.Elenco)
        {
            var artistaDTO = new ReadElencoDTO
            {
                Artista = artista.Nome!
            };
            artistas.Add(artistaDTO);
        }

        return artistas;
    }

    [HttpGet("filmografia/{id}")]
    public IEnumerable<ReadFilmografiaDTO> ExibirFilmografia(int id)
    {
        var artista = _context.Artistas.Include(artista => artista.Filmografia).FirstOrDefault(artista => artista.Id == id);
        List<ReadFilmografiaDTO> filmes = new();

        foreach (var filme in artista!.Filmografia)
        {
            var filmeDTO = new ReadFilmografiaDTO
            {
                Filme = filme.Titulo!
            };
            filmes.Add(filmeDTO);
        }

        return filmes;
    }
}
