using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Domain
{
    public class LibraryDataContext : DbContext
    {

        public LibraryDataContext(DbContextOptions<LibraryDataContext> ctx) : base(ctx) { }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(b => b.Author).HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(b => b.Genre).HasMaxLength(200);
            // etc. etc.

            modelBuilder.Entity<Book>().HasData(
                    new Book {  Id = 1, Title = "Walden", Author="Thoreau", Genre="Philosophy", NumberOfPages = 322},
                    new Book {  Id = 2, Title="In the Penal Colony", Author="Franz Kafka", Genre="Fiction", NumberOfPages = 180},
                    new Book {  Id = 3, Title = "The Trial", Author="Franz Kafka", Genre="Fiction", NumberOfPages = 223}
                );
        }
    }
}
