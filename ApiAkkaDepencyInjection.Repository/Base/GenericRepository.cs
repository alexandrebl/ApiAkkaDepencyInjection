using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ApiAkkaDepencyInjection.Domain;

namespace ApiAkkaDepencyInjection.Repository.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected List<T> Repository;
        protected GenericRepository()
        {
            Repository = new List<T>();
        }

        public IEnumerable<T> Query(Func<T, bool> predicate)
        {
            return Repository.Where(predicate);
        }
    }
}
