using Akka.Actor;
using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using System;

namespace ApiAkkaDepencyInjection.Services.Actors
{
    public class BookQueryActor : ReceiveActor
    {
        private readonly IBookRepository _bookRepository;

        public BookQueryActor(IBookRepository bookRepository) : this()
        {
            _bookRepository = bookRepository;
        }

        private BookQueryActor()
        {
            this.Receive<string>(query =>
            {
                var result = _bookRepository.Query(query);

                Sender.Tell(result);
            });

            this.Receive<Func<Book, bool>>(expression =>
            {
                var result = _bookRepository.Query(expression);

                Sender.Tell(result);
            });

            this.Receive<Book>(draw => { _bookRepository.Add(draw); });
        }
    }
}