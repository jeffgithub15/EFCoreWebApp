using DataLayer;
using DataLayer.Models;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementations
{
    public class ChangePubDateService : IChangePubDateService
    {
        private readonly EfCoreContext _dbContext;

        public ChangePubDateService(EfCoreContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ChangePubDateDto GetOriginal(int id)
        {
            return this._dbContext.Books
                .Select(p => new ChangePubDateDto
                {
                    BookId = p.BookId,
                    Title = p.Title,
                    PublishedOn = p.PublishedOn
                })
                .Single(k => k.BookId == id);
        }

        public Book UpdateBook(ChangePubDateDto dto)
        {
            var book = this._dbContext.Books.SingleOrDefault(
      x => x.BookId == dto.BookId);
            if (book == null)
                throw new ArgumentException(
                    "Book not found");
            book.PublishedOn = dto.PublishedOn;
            this._dbContext.SaveChanges();
            return book;
        }
    }
}
