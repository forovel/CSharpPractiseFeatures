using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
                
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookChapter> Chapters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bookBuilder = modelBuilder.Entity<Book>();
            bookBuilder.HasMany(b => b.Chapters).WithOne(c => c.Book).HasForeignKey(c => c.BookId);
            bookBuilder.Property(b => b.Title).HasMaxLength(120).IsRequired();
            bookBuilder.Property(b => b.Publisher).HasMaxLength(40).IsRequired(false);
            bookBuilder.Property(b => b.Isbn).HasMaxLength(20).IsRequired(false);

            var chapterBuilder = modelBuilder.Entity<BookChapter>();
            chapterBuilder.Property(c => c.Title).HasMaxLength(120);
            chapterBuilder.HasOne(c => c.Book).WithMany(b => b.Chapters).HasForeignKey(c => c.BookId);
        }
    }
}
