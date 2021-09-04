using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IBookService
    {
        IList<BookDto> GetAllBooks();
    }
}
