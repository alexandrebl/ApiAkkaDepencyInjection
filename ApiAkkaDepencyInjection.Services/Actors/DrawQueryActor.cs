using Akka.Actor;
using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using System;

namespace ApiAkkaDepencyInjection.Services.Actors
{
    public class DrawQueryActor : ReceiveActor
    {
        private readonly IDrawRepository _drawRepository;

        public DrawQueryActor(IDrawRepository drawRepository) : this()
        {
            _drawRepository = drawRepository;
        }

        private DrawQueryActor()
        {
            this.Receive<string>(query =>
            {
                var result = _drawRepository.Query(query);

                Sender.Tell(result);
            });

            this.Receive<Func<Draw, bool>>(expression =>
            {
                var result = _drawRepository.Query(expression);

                Sender.Tell(result);
            });

            this.Receive<Draw>(draw => { _drawRepository.Add(draw); });
        }
    }
}