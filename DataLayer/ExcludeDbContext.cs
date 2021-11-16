using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ExcludeDbContext : DbContext
    {
        public DbSet<MyEntityClass> MyEntities { get; set; }

        protected override void OnModelCreating
        (ModelBuilder modelBuilder)
        {
            //if (Database.IsSqlite())
            //{
            //    modelBuilder.Entity<Book>()
            //    .Property(e => e.Price)
            //    .HasConversion<double>();
            //    modelBuilder.Entity<PriceOffer>()
            //    .Property(e => e.NewPrice)
            //    .HasConversion<double>();
            //}

            var utcConverter = new ValueConverter<DateTime, DateTime>(
             toDb => toDb,
             fromDb =>
             DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            modelBuilder.Entity<ValueConversionExample>()
             .Property(e => e.DateTimeUtcUtcOnReturn)
             .HasConversion(utcConverter);


            modelBuilder.Entity<MyEntityClass>()
           .Ignore(b => b.LocalString);
            modelBuilder.Ignore<ExcludeClass>();
        }
    }
}
                                                                                                                            