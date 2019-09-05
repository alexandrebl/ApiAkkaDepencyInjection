using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ApiAkkaDepencyInjection.Repository.Support;

namespace ApiAkkaDepencyInjection.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _list;

        public BookRepository(bool seed = true)
        {
            if (seed) _list = BookSeed.GetSeed();
        }

        public void Add(Book draw)
        {
            _list.Add(draw);
        }

        public IEnumerable<Book> Query(Func<Book, bool> predicate)
        {
            return _list.Where(predicate);
        }

        public IEnumerable<Book> Query(string code)
        {
            return _list.Where(w => w.Code == code);
        }
    }
}