using CivittaTask.DatabaseProvider.Entities;

using Microsoft.EntityFrameworkCore;

namespace CivittaTask.DatabaseProvider
{
    public class DataContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<Day> Days { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                 .HasOne(c => c.FromDate)
                 .WithOne()
                 .HasForeignKey<Country>(c => c.FromDateId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Country>()
                .HasOne(c => c.ToDate)
                .WithOne()
                .HasForeignKey<Country>(c => c.ToDateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
