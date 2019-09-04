using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiAkkaDepencyInjection.Repository
{
    public class DrawRepository : IDrawRepository
    {
        private readonly List<Draw> _list;

        public DrawRepository()
        {
            _list = Seed();
        }

        private static List<Draw> Seed()
        {
            return new List<Draw> {
                new Draw("123", DateTime.UtcNow, 12, 34, 56, 78),
                new Draw("456", DateTime.UtcNow, 21, 43, 65, 87),
                new Draw("789", DateTime.UtcNow, 56, 67, 78, 90)
            };
        }

        public void Add(Draw draw)
        {
            _list.Add(draw);
        }

        public IEnumerable<Draw> Query(Func<Draw, bool> predicate)
        {
            return _list.Where(predicate);
        }

        public IEnumerable<Draw> Query(string code)
        {
            return _list.Where(w => w.Code == code);
        }
    }
}