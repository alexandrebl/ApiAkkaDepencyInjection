using Akka.Actor;

namespace ApiAkkaDepencyInjection.CrossCuting.Providers
{
    public sealed class AkkaProviders
    {
        public delegate IActorRef DrawActorProvider();
    }
}