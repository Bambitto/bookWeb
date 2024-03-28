using bookWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookWebApi.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Title).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Book>()
                .Property(x=> x.Author).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Book>()
                .Property(x=> x.Description).HasMaxLength(512);

            modelBuilder.Entity<Book>()
                .Property(x => x.Genre).IsRequired();
        }
    }
}
