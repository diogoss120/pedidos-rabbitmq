namespace Order.Api.Bus.Interfaces
{
    public interface IEventBus
    {
        Task PublishAsync<T>(string key, T message);
    }
}
