namespace Shared.Messaging
{
    public interface IEventBus
    {
        Task PublishAsync<T>(string key, T message);
    }
}
