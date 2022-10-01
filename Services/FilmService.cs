using estudo_c_.Data;
using estudo_c_.Models;
using estudo_c_.Services.Interfaces;
using estudo_c_.Data.Dtos.Film;
using AutoMapper;
namespace estudo_c_.Services;
public class FilmService : IFilmService
{

    private AppDbContext _context;
    private IMapper _mapper;
    public FilmService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public ReadFilmDto GetById(int id)
    {
        Film film = _context.Films.FirstOrDefault<Film>(film => film.Id == id);
        if (film != null)
        {
            ReadFilmDto filmDto = _mapper.Map<ReadFilmDto>(film);
            return filmDto;
        }
        return null;
    }
    public IEnumerable<Film> GetAll()
    {
        return _context.Films;
    }
    public Film Create(CreateFilmDto data)
    {
        Film film = _mapper.Map<Film>(data);
        _context.Films.Add(film);
        _context.SaveChanges();
        return film;
    }

    public Film Update(int id, UpdateFilmDto data)
    {
        Film film = _context.Films.FirstOrDefault<Film>(film => film.Id == id);
        if(film == null){
            return null;
        }
        _mapper.Map(data, film);
        _context.SaveChanges();
        return film;
    }
    public Film Remove(int id)
    {
        Film film = _context.Films.FirstOrDefault<Film>(film => film.Id == id);
        if(film == null){
            return null;
        }
        _context.Remove(film);
        return film;

    }

}