using System.Threading;
using System.Threading.Tasks;
using ContactManager.API.Infrastructure.EntityConfiguration;
using ContactManager.Domain.Model;
using ContactManager.Domain.SeedOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactManager.API.Infrastructure
{
    public class ContactManagerContext : DbContext, IUnitOfWork
    {
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }

        public ContactManagerContext(DbContextOptions<ContactManagerContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CostumerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        }
    }
    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<ContactManagerContext>
    {
        public ContactManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder =  new DbContextOptionsBuilder<ContactManagerContext>()
                .UseSqlServer("Server=tcp:identitysrv.database.windows.net,1433;Initial Catalog=contactDb;Persist Security Info=False;User ID=identity_user;Password=Nov@senha123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ContactManagerContext(optionsBuilder.Options);
        }
    }
}