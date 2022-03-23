using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet <Company> Companies { get; set; }
        public DbSet <Store> Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Store>()
                .HasOne(s => s.Companies)
                .WithMany(x => x.Stores)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = Guid.NewGuid(), Name = "Apple Company", OrganizationNumber = 123321456, Notes = "Apple Inc. är ett amerikanskt dator - " +
                "och hemelektronikföretag grundat 1976 av Steve Jobs," +
                " Steve Wozniak och Ronald Wayne. Företaget har cirka 147 000 " +
                "anställda och omsatte 2020 nästan 274.52 miljarder amerikanska dollar." },
                new Company { Id = Guid.NewGuid(), Name = "Ikea Company", OrganizationNumber = 111111332, Notes = "Ikea Group, av företaget skrivet IKEA Group, är ett multinationellt möbelföretag," +
                " som grundades i Sverige år 1943 av Ingvar Kamprad som ett postorderföretag." +
                " Företaget ägs av en stiftelse i Nederländerna, men styrs alltjämt av familjen Kamprad." }
                );

           
                



        }


    }
}
