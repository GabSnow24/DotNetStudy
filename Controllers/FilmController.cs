namespace estudo_c_.Controllers;
using Microsoft.AspNetCore.Mvc;
using estudo_c_.Models;
using estudo_c_.Data;
using estudo_c_.Data.Dtos.Film;
using estudo_c_.Services.Interfaces;
using AutoMapper;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    private IFilmService _service;
    public FilmController(AppDbContext context, IMapper mapper, [FromServices]IFilmService service )
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public IActionResult createFilm([FromBody] CreateFilmDto filmDto)
    {

        Film film = _service.Create(filmDto);
        return CreatedAtAction(nameof(getFilmById), new { Id = film.Id }, film);
    }

    [HttpGet]
    public IEnumerable<Film> getFilms()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult getFilmById(int id)
    {

        ReadFilmDto film = _service.GetById(id);
        if (film != null)
        {
            return Ok(film);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult updateFilm(int id, [FromBody] UpdateFilmDto filmDto)
    {
        Film film = _service.Update(id, filmDto);
        if (film == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteFilm(int id)
    {
        Film film = _service.Remove(id);
        if (film == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}
