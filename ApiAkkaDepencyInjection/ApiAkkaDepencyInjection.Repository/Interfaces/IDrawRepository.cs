using ApiAkkaDepencyInjection.Domain;
using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Repository.Interfaces
{
    public interface IDrawRepository
    {
        void Add(Draw draw);

        IEnumerable<Draw> Query(Func<Draw, bool> predicate);

        IEnumerable<Draw> Query(string code);
    }
}