using DataLayer.Models;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IChangePubDateService
    {
        ChangePubDateDto GetOriginal(int id);
        Book UpdateBook(ChangePubDateDto dto);
    }
}
