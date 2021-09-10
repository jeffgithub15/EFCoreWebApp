using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace EFCoreAspNetWebApp.Extensions
{
    public static class EFExtensions
    {
        public static async Task MigrateDatabaseAsync
            (this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services
                    .GetRequiredService<EfCoreContext>())
                {
                    try
                    {
                        await context.Database.MigrateAsync();
                        await SeedDatabaseAsync(context);
                        //Put any complex database seeding here
                    }
                    catch (Exception ex)
                    {
                        var logger = services
                            .GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex,
                        "An error occurred while migrating the database.");

                        throw;
                    }
                }
            }
        }


        public static async Task SeedDatabaseAsync
            (this EfCoreContext context)
        {
            if (context.Books.Any()) return;

            var books = CreateFourBooks();
            context.Books.AddRange(books);
            await context.SaveChangesAsync();
        }

        private static List<Book> CreateFourBooks()
        {
            var books = new List<Book>();

            var book1 = new Book
            {
                Title = "Refactoring",
                Description = "Improving the design of existing code",
                PublishedOn = new DateTime(1999, 7, 8),
                Price = 40,
            };
            books.Add(book1);

            var book2 = new Book
            {
                Title = "Patterns of Enterprise Application Architecture",
                Description = "Written in direct response to the stiff challenges",
                PublishedOn = new DateTime(2002, 11, 15),
                Price = 53,
            };
            books.Add(book2);

            var book3 = new Book
            {
                Title = "Domain-Driven Design",
                Description = "Linking business needs to software design",
                PublishedOn = new DateTime(2003, 8, 30),
                Price = 56
            };
            books.Add(book3);

            var book4 = new Book
            {
                Title = "Quantum Networking",
                Description = "Entangled quantum networking provides faster-than-light data communications",
                PublishedOn = new DateTime(2057, 1, 1),
                Price = 220
            };

            books.Add(book4);

            return books;
        }
    }
}
