using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Base;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        void Add(Book draw);

        IEnumerable<Book> Query(string code);
    }
}