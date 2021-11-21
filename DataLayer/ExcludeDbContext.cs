using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DataLayer
{
    public class ExcludeDbContext : DbContext
    {
        public DbSet<MyEntityClass> MyEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var utcConverter = new ValueConverter<DateTime, DateTime>(
             toDb => toDb,
             fromDb =>
             DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entityProperty in entityType.GetProperties())
                {
                    if (entityProperty.ClrType == typeof(DateTime)
                    && entityProperty.Name.EndsWith("Utc"))
                    {
                        entityProperty.SetValueConverter(utcConverter);
                    }
                }
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entityProperty in entityType.GetProperties())
                {
                    if (entityProperty.ClrType == typeof(DateTime)
                    && entityProperty.Name.EndsWith("Utc"))
                    {
                        entityProperty.SetValueConverter(utcConverter);
                    }
                    if (entityProperty.ClrType == typeof(decimal)
                    && entityProperty.Name.Contains("Price"))
                    {
                        entityProperty.SetPrecision(9);
                        entityProperty.SetScale(2);
                    }
                    if (entityProperty.ClrType == typeof(string)
                    && entityProperty.Name.EndsWith("Url"))
                    {
                        entityProperty.SetIsUnicode(false);
                    }
                }
            }

                                                                                                                
            //============
            //modelBuilder.Entity<MyEntityClass>()
            //    .HasIndex(i => i.MyEntityClassId)
            //    .IsUnique()
            //    .HasFilter("NOT SoftDeleted");


            //if (Database.IsSqlite())
            //{
            //    modelBuilder.Entity<Book>()
            //    .Property(e => e.Price)
            //    .HasConversion<double>();
            //    modelBuilder.Entity<PriceOffer>()
            //    .Property(e => e.NewPrice)
            //    .HasConversion<double>();
            //}



            //====================
            // var utcConverter = new ValueConverter<DateTime, DateTime>(
            //  toDb => toDb,
            //  fromDb =>
            //  DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            // modelBuilder.Entity<ValueConversionExample>()
            //  .Property(e => e.DateTimeUtcUtcOnReturn)
            //  .HasConversion(utcConverter);


            // modelBuilder.Entity<MyEntityClass>()
            //.Ignore(b => b.LocalString);
            // modelBuilder.Ignore<ExcludeClass>();




        }
    }

    
}
