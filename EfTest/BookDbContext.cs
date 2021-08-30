using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfTest
{
    //public class BookDbContext : DbContext
    //{
    //    public BookDbContext()
    //    {
    //    }
    //}

    //public class EfCoreContext : DbContext
    //{
    //    public EfCoreContext(DbContextOptions<EfCoreContext> options)
    //        : base(options)
    //    {

    //    }

    //    public DbSet<Book> Books { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<BookAuthor>()
    //           .HasKey(x => new { x.BookId, x.AuthorId });

    //        modelBuilder.Entity<LineItem>()
    //            .HasOne(p => p.ChosenBook)
    //            .WithMany()
    //            .OnDelete(DeleteBehavior.Restrict);

    //        modelBuilder.Entity<Book>()
    //            .HasQueryFilter(p => !p.SoftDeleted);

    //        modelBuilder.Entity<Order>()
    //            .HasQueryFilter(x => x.CustomerId == _userId);
    //    }
    //}
}
