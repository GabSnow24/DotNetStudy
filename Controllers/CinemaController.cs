namespace estudo_c_.Controllers;
using Microsoft.AspNetCore.Mvc;
using estudo_c_.Data.Dtos.Cinema;
using estudo_c_.Models;
using estudo_c_.Data;
using estudo_c_.Profiles;
using AutoMapper;
public class CinemaController : ControllerBase{

    private AppDbContext _context;
    private IMapper _mapper;
    public CinemaController(AppDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult createCinema([FromBody] CreateCinemaDto cinemaDto){
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getCinemaById), new {Id = cinema.Id}, cinema);

    }

    [HttpGet]
    public IEnumerable<Cinema> getAllCinemas(){
        return _context.Cinemas;
    }

    [HttpGet("{id}")]
    public IActionResult getCinemaById(int id){
        Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);
        if(cinema != null){
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult updateCinema(int id, UpdateCinemaDto cinemaDto){
        Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);
        if(cinema == null){
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult deleteCinema(int id){
        Cinema cinema = _context.Cinemas.FirstOrDefault<Cinema>(cinema => cinema.Id == id);
        if(cinema == null){
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}