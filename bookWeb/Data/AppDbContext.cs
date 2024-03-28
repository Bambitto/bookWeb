using bookWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookWebApi.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(b => b.Book)
                .WithMany(r => r.Reviews)
                .HasForeignKey(b => b.BookId);
            
            modelBuilder.Entity<Review>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Review>()
                .Property(x => x.Comment).HasMaxLength(512);


            modelBuilder.Entity<Book>()
                .Property(x => x.Title).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Book>()
                .Property(x => x.Author).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Book>()
                .Property(x => x.Description).HasMaxLength(512);

            modelBuilder.Entity<Book>()
                .Property(x => x.Genre).IsRequired();


            modelBuilder.Entity<User>()
                .Property(x => x.Email).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName).HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(x => x.Password).IsRequired();

        }
    }
}
