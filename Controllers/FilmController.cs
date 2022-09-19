namespace estudo_c_.Controllers;
using Microsoft.AspNetCore.Mvc;
using estudo_c_.Models;
using estudo_c_.Data;
using estudo_c_.Data.Dtos;
using System;
using AutoMapper;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;
    public FilmController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult createFilm([FromBody] CreateFilmDto filmDto)
    {

        Film film = _mapper.Map<Film>(filmDto);
        _context.Films.Add(film);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getFilmById), new { Id = film.Id }, film);
    }

    [HttpGet]
    public IEnumerable<Film> getFilms()
    {
        return _context.Films;
    }

    [HttpGet("{id}")]
    public IActionResult getFilmById(int id)
    {

        Film film = _context.Films.FirstOrDefault<Film>(film => film.Id == id);
        if (film != null)
        {
            ReadFilmDto filmDto = _mapper.Map<ReadFilmDto>(film);
            return Ok(filmDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult updateFilm(int id, [FromBody] UpdateFilmDto filmDto)
    {
        Film film = _context.Films.FirstOrDefault<Film>(film => film.Id == id);
        if (film == null)
        {
            return NotFound();
        }
        _mapper.Map(filmDto, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteFilm(int id)
    {
        Film film = _context.Films.FirstOrDefault<Film>(film => film.Id == id);
        if (film == null)
        {
            return NotFound();
        }
        _context.Remove(film);
        _context.SaveChanges();
        return NoContent();
    }
}
