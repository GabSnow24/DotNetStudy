using AutoMapper;
using estudo_c_.Data.Dtos.Film;
using estudo_c_.Models;
namespace estudo_c_.Profiles;
public class FilmProfile : Profile{
    public FilmProfile()
    {
        CreateMap<CreateFilmDto, Film>();
        CreateMap<Film, ReadFilmDto>();
        CreateMap<UpdateFilmDto, Film>();
    }
    
}