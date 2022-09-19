using Microsoft.EntityFrameworkCore;
using estudo_c_.Models;
namespace estudo_c_.Data;
public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> options) : base(options)
    {

    }

    public DbSet<Film> Films { get; set; }
}