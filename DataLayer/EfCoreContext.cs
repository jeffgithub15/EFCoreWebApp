using DataLayer.ModelConfigs;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(
            DbContextOptions<EfCoreContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeEntity>()
                .HasKey(x => x.NonStandardKeyName);

            modelBuilder.Entity<BookAuthor>()
               .HasKey(x => new { x.BookId, x.AuthorId });



            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookAuthorConfig());
            modelBuilder.ApplyConfiguration(new PriceOfferConfig());
            modelBuilder.ApplyConfiguration(new LineItemConfig()); 


            //modelBuilder.Entity<Book>()
            //.Property(x => x.PublishedOn)
            //.HasColumnType("date");

            //modelBuilder.Entity<Book>()
            //    .Property(x => x.ImageUrl)
            //    .IsUnicode(false);


            //modelBuilder.Entity<Book>()
            //    .HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}                                                                                                        
