using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Base;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using ApiAkkaDepencyInjection.Repository.Support;
using System.Collections.Generic;
using System.Linq;

namespace ApiAkkaDepencyInjection.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(bool seed = true)
        {
            if (seed) Repository = BookSeed.GetSeed();
        }

        public void Add(Book draw)
        {
            Repository.Add(draw);
        }

        public IEnumerable<Book> Query(string code)
        {
            return Repository.Where(w => w.Code == code);
        }
    }
}