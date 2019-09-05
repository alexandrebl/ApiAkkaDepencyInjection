using Akka.Actor;
using ApiAkkaDepencyInjection.CrossCuting.Providers;
using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Services
{
    public sealed class QueryServices : IQueryServices
    {
        private readonly IActorRef _bookActor;

        public QueryServices(CustomProviders.BookActorProvider bookActorProvider)
        {
            _bookActor = bookActorProvider();
        }

        public void Insert(Book book)
        {
            _bookActor.Tell(book);
        }

        public IEnumerable<Book> Query()
        {
            var expression = new Func<Book, bool>(w => w.PublishDate <= DateTime.UtcNow);

            var result = _bookActor.Ask<IEnumerable<Book>>(expression).Result;

            return result;
        }

        public IEnumerable<Book> QueryByCode(string code)
        {
            var result = _bookActor.Ask<IEnumerable<Book>>(code).Result;

            return result;
        }

        public IEnumerable<Book> Query(DateTime startDataDateTime, DateTime endDateTime)
        {
            var expression = new Func<Book, bool>(
                w => w.PublishDate >= startDataDateTime && w.PublishDate <= endDateTime);

            var result = _bookActor.Ask<IEnumerable<Book>>(expression).Result;

            return result;
        }

        public IEnumerable<Book> QueryByIsbn(string isbn)
        {
            var expression = new Func<Book, bool>(w => w.Isbn == isbn);

            var result = _bookActor.Ask<IEnumerable<Book>>(expression).Result;

            return result;
        }

        public IEnumerable<Book> QueryByAuthorAndDate(
            string author, DateTime startDataDateTime, DateTime endDateTime)
        {
            var expression = new Func<Book, bool>(
                w => w.Autor == author &&
                     w.PublishDate >= startDataDateTime &&
                        w.PublishDate <= endDateTime);

            var result = _bookActor.Ask<IEnumerable<Book>>(expression).Result;

            return result;
        }
    }
}