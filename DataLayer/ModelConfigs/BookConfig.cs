using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ModelConfigs
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.PublishedOn).HasColumnType("date");

            builder.Property(p => p.Price).HasPrecision(9, 2);

            builder.Property(x => x.ImageUrl).IsUnicode(false);

            builder.HasIndex(x => x.PublishedOn);
        }
    }
}                                                                                                                            
 