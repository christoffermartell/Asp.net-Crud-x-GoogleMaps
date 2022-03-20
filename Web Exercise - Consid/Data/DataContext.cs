using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet <Companies> Companies { get; set; }
        public DbSet <Stores> Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Stores>()
                .HasOne(s => s.Companies)
                .WithMany(x => x.Stores)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
                



        }


    }
}
