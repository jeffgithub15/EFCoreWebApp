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
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
