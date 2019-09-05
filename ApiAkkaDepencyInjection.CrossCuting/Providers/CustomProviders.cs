using Akka.Actor;

namespace ApiAkkaDepencyInjection.CrossCuting.Providers
{
    public sealed class CustomProviders
    {
        public delegate IActorRef BookActorProvider();
    }
}