using Microsoft.EntityFrameworkCore;
using Prouduct.Database.entities;

namespace Prouduct.Database.context
{
  
    public class Applicationcontext : DbContext
    {
        public Applicationcontext(DbContextOptions<Applicationcontext> options) : base(options)
        {

        }

       
        public DbSet<Company> Companies  { get; set; }
        
    }
}
