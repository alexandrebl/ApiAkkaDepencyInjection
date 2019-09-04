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
        private readonly IActorRef _drawActor;

        public QueryServices(AkkaProviders.DrawActorProvider drawActorProvider)
        {
            _drawActor = drawActorProvider();
        }

        public void Add(Draw draw)
        {
            _drawActor.Tell(draw);
        }

        public IEnumerable<Draw> Query(Func<Draw, bool> predicate)
        {
            var result = _drawActor.Ask<IEnumerable<Draw>>(predicate).Result;

            return result;
        }

        public IEnumerable<Draw> Query(string code)
        {
            var result = _drawActor.Ask<IEnumerable<Draw>>(code).Result;

            return result;
        }
    }
}