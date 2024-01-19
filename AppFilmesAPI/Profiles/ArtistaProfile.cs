using AppFilmesAPI.Data.DTOs;
using AppFilmesAPI.Models;
using AutoMapper;

namespace AppFilmesAPI.Profiles;

public class ArtistaProfile : Profile
{
    public ArtistaProfile()
    {
        CreateMap<CreateArtistaDTO, Artista>();
        CreateMap<UpdateArtistaDTO, Artista > ();
        CreateMap<ReadArtistaDTO, Artista>();
    }
}
