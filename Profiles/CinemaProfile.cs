using AutoMapper;
using estudo_c_.Data.Dtos.Cinema;
using estudo_c_.Models;
namespace estudo_c_.Profiles;
public class CinemaProfile : Profile{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Cinema>();
    }
    
}