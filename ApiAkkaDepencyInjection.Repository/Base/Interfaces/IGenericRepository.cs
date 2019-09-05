using System;
using System.Collections.Generic;

namespace ApiAkkaDepencyInjection.Repository.Base
{
    public interface IGenericRepository<out T> where T : class
    {
        IEnumerable<T> Query(Func<T, bool> predicate);
    }
}