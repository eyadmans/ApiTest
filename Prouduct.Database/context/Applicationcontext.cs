using Microsoft.EntityFrameworkCore;
using production.Database.entities;
using Prouduction.Database.entities;

namespace Prouduction.Database.context
{
  
    public class Applicationcontext : DbContext
    {
        public Applicationcontext(DbContextOptions<Applicationcontext> options) : base(options)
        {

        }

       
        public DbSet<Company> Companies  { get; set; }
        public DbSet<CompanyCountry > CompanyCountries { get; set; }
        public DbSet<production.Database.entities.Product> Products  { get; set; }
    }
}
