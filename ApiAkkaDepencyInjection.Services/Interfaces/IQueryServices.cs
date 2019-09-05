using ApiAkkaDepencyInjection.Domain;
using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Services.Interfaces
{
    public interface IQueryServices
    {
        void Insert(Book book);

        IEnumerable<Book> Query();

        IEnumerable<Book> QueryByCode(string code);

        IEnumerable<Book> Query(DateTime startDataDateTime, DateTime endDateTime);

        IEnumerable<Book> QueryByIsbn(string isbn);

        IEnumerable<Book> QueryByAuthorAndDate(
            string author, DateTime startDataDateTime, DateTime endDateTime);
    }
}