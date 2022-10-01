using Microsoft.EntityFrameworkCore;
using estudo_c_.Models;
namespace estudo_c_.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
}