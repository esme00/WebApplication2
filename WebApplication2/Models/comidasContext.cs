using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class comidasContext : DbContext
    {
        public comidasContext(DbContextOptions<comidasContext> options) : base(options)
        {

        }

        public DbSet<comidas> comidas { get; set; }
    }
}
