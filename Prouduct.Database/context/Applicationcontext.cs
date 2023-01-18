using Microsoft.EntityFrameworkCore;
using production.Database.entities;
using Production.Database.entities;
using Prouduction.Database.entities;

namespace Prouduction.Database.context
{
  
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies  { get; set; }
        public DbSet<CompanyCountry > CompanyCountries { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<ProductCompany> ProductCompanies { get; set; }

    }
}
