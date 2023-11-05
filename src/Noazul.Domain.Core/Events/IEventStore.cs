using NetDevPack.Messaging;

namespace Noazul.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}