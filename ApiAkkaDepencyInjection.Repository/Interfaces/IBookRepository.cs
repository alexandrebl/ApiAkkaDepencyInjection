using ApiAkkaDepencyInjection.Domain;
using System;
using System.Collections.Generic;
using ApiAkkaDepencyInjection.Repository.Base;

namespace ApiAkkaDepencyInjection.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        void Add(Book draw);

        IEnumerable<Book> Query(string code);
    }
}