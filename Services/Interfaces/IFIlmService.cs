namespace estudo_c_.Services.Interfaces;
using estudo_c_.Models;
using estudo_c_.Data.Dtos.Film;
public interface IFilmService : IGenericService<Film>{
    public Film Create (CreateFilmDto data);
    public Film Update (int id, UpdateFilmDto data);

    public ReadFilmDto GetById(int id);
}