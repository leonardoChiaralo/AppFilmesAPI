using AppFilmesAPI.Data;
using AppFilmesAPI.Data.DTOs.Filme;
using AppFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private AppFilmesContext _context;

    public FilmeController(AppFilmesContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RegistrarFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
        Filme filme = new Filme 
        {
            Titulo = filmeDTO.Titulo,
            Ano = filmeDTO.Ano,
            Genero = filmeDTO.Genero,
            Diretor = filmeDTO.Diretor,
            Duracao = filmeDTO.Duracao,
            Nota = filmeDTO.Nota,
        };
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirFilmePorId), new {id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> ExibirFilmes()
    {
        var filmes = _context.Filmes.ToList();
        var readFilmes = filmes.Select(filme => new ReadFilmeDTO 
        {
            Titulo = filme.Titulo,
            Ano = filme.Ano,
            Genero = filme.Genero,
            Diretor = filme.Diretor,
            Duracao = filme.Duracao,
            Nota = filme.Nota,
        }).ToList();
        return readFilmes;
    }

    [HttpGet("paginados")]
    public IEnumerable<ReadFilmeDTO> ExibirFilmesPaginados([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var filmes = _context.Filmes.ToList();
        var readFilmes = filmes.Select(filme => new ReadFilmeDTO
        {
            Titulo = filme.Titulo,
            Ano = filme.Ano,
            Genero = filme.Genero,
            Diretor = filme.Diretor,
            Duracao = filme.Duracao,
            Nota = filme.Nota,
        }).ToList();
        return readFilmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ExibirFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var readFilme = new ReadFilmeDTO
        {
            Titulo = filme.Titulo,
            Ano = filme.Ano,
            Genero = filme.Genero,
            Diretor = filme.Diretor,
            Duracao = filme.Duracao,
            Nota = filme.Nota,
        };
        return Ok(readFilme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        filme.Titulo = filmeDTO.Titulo;
        filme.Ano = filmeDTO.Ano;
        filme.Genero = filmeDTO.Genero;
        filme.Diretor = filmeDTO.Diretor;
        filme.Duracao = filmeDTO.Duracao;
        filme.Nota = filmeDTO.Nota;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
