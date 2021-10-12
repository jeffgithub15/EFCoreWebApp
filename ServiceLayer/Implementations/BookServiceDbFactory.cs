using DataLayer;

using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Implementations
{
    public class BookServiceDbFactory : IBookService
    {
        private readonly EfCoreContext _dbContext;

        public BookServiceDbFactory(
            IDbContextFactory<EfCoreContext> dbContext)
        {
            this._dbContext = dbContext.CreateDbContext();
        }

        public IList<BookDto> GetAllBooks()
        {
            return this._dbContext.Books.Select(i => new BookDto
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
