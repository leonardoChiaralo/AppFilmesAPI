using AppFilmesAPI.Data;
using AppFilmesAPI.Data.DTOs;
using AppFilmesAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistaController : ControllerBase
{
    private ArtistaContext _context;
    private IMapper _mapper;

    public ArtistaController(ArtistaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegistrarArtista([FromBody] CreateArtistaDTO artistaDTO)
    {
        Artista artista = _mapper.Map<Artista>(artistaDTO);
        _context.Artistas.Add(artista);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirArtistaPorId), new { id = artista.Id }, artista);
    }

    [HttpGet]
    public IEnumerable<ReadArtistaDTO> ExibirArtistas()
    {
        return _mapper.Map<List<ReadArtistaDTO>>(_context.Artistas);
    }

    [HttpGet("paginados")]
    public IEnumerable<ReadArtistaDTO> ExibirArtistasPaginados([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadArtistaDTO>>(_context.Artistas.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult ExibirArtistaPorId(int id)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);
        if (artista == null) return NotFound();
        var artistaDTO = _mapper.Map<ReadArtistaDTO>(artista);
        return Ok(artistaDTO);
    }

    [HttpGet("nome/{nome}")]
    public IActionResult ExibirArtistaPorNome(string nome)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Nome == nome);
        if (artista == null) return NotFound();
        var artistaDTO = _mapper.Map<ReadArtistaDTO>(artista);
        return Ok(artistaDTO);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarArtista(int id, [FromBody] UpdateArtistaDTO artistaDTO)
    {
        var artista = _context.Artistas.FirstOrDefault(artista => artista.Id == id);
        if (artista == null) return NotFound();
        _mapper.Map(artistaDTO, artista);
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
