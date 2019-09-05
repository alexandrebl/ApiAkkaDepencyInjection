using ApiAkkaDepencyInjection.Domain;
using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Repository.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book draw);

        IEnumerable<Book> Query(Func<Book, bool> predicate);

        IEnumerable<Book> Query(string code);
    }
}