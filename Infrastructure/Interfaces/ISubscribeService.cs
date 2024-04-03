using Infrastructure.Dtos;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infrastructure.Interfaces;

public interface ISubscribeService
{
    Task<bool> CreateSubscriberAsync(SubscribeRegistrationForm form);
    Task<IEnumerable<SubscriberEntity>> GetAllSubscribersAsync();
    Task<SubscriberEntity> GetOneSubscriberAsync(int id);
    Task<bool> UpdateSubscriberAsync(int id, string email);
    Task<bool> DeleteSubscriberAsync(int id);
}
