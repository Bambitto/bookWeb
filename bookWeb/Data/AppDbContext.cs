using bookWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookWebApi.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Genre1 = Guid.NewGuid();
            var Genre2 = Guid.NewGuid();
            var Book1 = Guid.NewGuid();
            var Book2 = Guid.NewGuid();
            var User1 = Guid.NewGuid();



            #region Review
            
            modelBuilder.Entity<Review>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Review>()
                .ToTable("Review");

            modelBuilder.Entity<Review>()
                .Property(x => x.Comment).HasMaxLength(512);

            #endregion


            #region Book
            modelBuilder.Entity<Book>()
                .HasOne(g => g.Genre)
                .WithMany(r => r.Books)
                .HasForeignKey(g => g.GenreId);

            modelBuilder.Entity<Book>()
                .HasMany(r => r.Reviews)
                .WithOne()
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Book>()
                .ToTable("Book");

            modelBuilder.Entity<Book>()
                .Property(x => x.Title).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Book>()
                .Property(x => x.Author).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Book>()
                .Property(x => x.Description).HasMaxLength(512);

            modelBuilder.Entity<Book>()
                .Property(x => x.GenreId).IsRequired();

            #endregion


            #region User
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(x => x.Email).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName).IsRequired().HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName).HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(x => x.Password).IsRequired();

            #endregion


            #region Genre
            modelBuilder.Entity<Genre>()
                .ToTable("Genres");

            modelBuilder.Entity<Genre>()
                .HasData(
                new Genre { Id = Genre1, Name = "Komedia" },
                new Genre { Id = Genre2, Name = "Kryminał" }
                );
            #endregion


            #region TestData

            modelBuilder.Entity<User>()
                .HasData(
                new User { Id = User1, Email = "test@test.com", FirstName = "Test", LastName = "Test", Password = "test123" }
                );

            modelBuilder.Entity<Book>()
                .HasData(
                new Book { Author = "Test", Title = "Test", CreatedDate = DateTime.Now, Description = "test", GenreId = Genre1, Id = Book1, UpdatedDate = DateTime.Now},
                new Book { Author = "Test2", Title = "Test2", CreatedDate = DateTime.Now, Description = "test2", GenreId = Genre2, Id = Book2, UpdatedDate = DateTime.Now }
                );

            modelBuilder.Entity<Review>()
                .HasData(
                new Review { Id = Guid.NewGuid(), BookId = Book1, Score = 4, Comment = "test", UserId = User1 },
                new Review { Id = Guid.NewGuid(), BookId = Book2, Score = 5, Comment = "test", UserId = User1 }
                );
            
            #endregion
        }
    }
}
