using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface ISubscribeRepository
{
    Task<bool> SubscriberExists(string email);
    Task<ICollection<SubscriberEntity>> GetAllSubscribersAsync();
    Task<SubscriberEntity> GetOneSubscriberById(int id);
    Task<bool> CreateSubscriber(SubscriberEntity subscriber);
    Task<bool> UpdateSubscriber(SubscriberEntity subscriber);
    Task<bool> DeleteSubscriber(int id);
}
