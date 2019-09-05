using ApiAkkaDepencyInjection.Domain;
using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Repository.Support
{
    public static class BookSeed
    {
        public static List<Book> GetSeed()
        {
            return new List<Book> {
                new Book("123", DateTime.UtcNow, "0001112222", "Slash"),
                new Book("456", DateTime.UtcNow, "3343434234", "Steve Vai"),
                new Book("789", DateTime.UtcNow, "6785846446", "Joe Satriani")
            };
        }
    }
}