using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ApiAkkaDepencyInjection.Repository.Base;
using ApiAkkaDepencyInjection.Repository.Support;

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