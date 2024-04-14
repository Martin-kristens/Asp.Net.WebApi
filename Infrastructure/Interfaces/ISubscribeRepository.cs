using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infrastructure.Interfaces;

public interface ISubscribeRepository
{
    Task<bool> SubscriberExists(string email);
    Task<ICollection<SubscriberEntity>> GetAllSubscribersAsync();
    Task<SubscriberEntity> GetOneSubscriberByEmail(string email);
    Task<bool> CreateSubscriber(SubscriberEntity subscriber);
    Task<bool> UpdateSubscriberAsync(SubscriberEntity subscriber);
    Task<bool> DeleteSubscriberAsync(SubscriberEntity subscriber);
}
