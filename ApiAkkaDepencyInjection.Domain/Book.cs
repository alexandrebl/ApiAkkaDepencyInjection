using System;

namespace ApiAkkaDepencyInjection.Domain
{
    public sealed class Book
    {
        public string Code { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Isbn { get; private set; }
        public string Autor { get; private set; }

        public Book(string code, DateTime publishDate, string isbn, string autor)
        {
            Code = code;
            PublishDate = publishDate;
            Isbn = isbn;
            Autor = autor;
        }
    }
}