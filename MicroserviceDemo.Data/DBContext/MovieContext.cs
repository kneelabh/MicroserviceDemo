using MicroserviceDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceDemo.Data.DBContext
{
    public class MovieContext : DbContext
    {
        public MovieContext(
            DbContextOptions<MovieContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}