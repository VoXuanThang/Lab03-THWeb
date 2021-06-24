namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookManagerContext : DbContext
    {
        public BookManagerContext()
            : base("name=BookManagerContext1")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Images)
                .IsFixedLength();
        }
    }
}
