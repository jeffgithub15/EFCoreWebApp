using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementations
{
    public class BookServiceNotDI : IBookService
    {
        public IList<BookDto> GetAllBooks()
        {
            const string connectionString = "Integrated Security=SSPI; " + 
                "Persist Security Info=False;Initial Catalog=EfCoreInActionDb2;Data Source=JEFFREYA-PC2";
            var optionsBuilder = new DbContextOptionsBuilder<EfCoreContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var options = optionsBuilder.Options;

            using (var context = new EfCoreContext(options))
            {
                return context.Books.Select(i => new BookDto
                {
                    BookId = i.BookId,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price,
                    PublishedOn = i.PublishedOn,
                    Publisher = i.Publisher,
                    SoftDeleted = i.SoftDeleted,
                    Title = i.Title

                }).ToList();
            }
        }
    }
}
