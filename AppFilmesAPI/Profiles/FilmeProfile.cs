using AppFilmesAPI.Data.DTOs;
using AppFilmesAPI.Models;
using AutoMapper;

namespace AppFilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
        CreateMap<Filme, ReadFilmeDTO>();
    }
}
