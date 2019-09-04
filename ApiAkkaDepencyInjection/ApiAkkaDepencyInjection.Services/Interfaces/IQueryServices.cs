using ApiAkkaDepencyInjection.Domain;
using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Services.Interfaces
{
    public interface IQueryServices
    {
        void Add(Draw draw);

        IEnumerable<Draw> Query(Func<Draw, bool> predicate);

        IEnumerable<Draw> Query(string code);
    }
}