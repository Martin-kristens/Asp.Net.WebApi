using Infrastructure.Dtos;

namespace Infrastructure.Interfaces;

public interface ISubscribeService
{
    Task<bool> CreateSubscriber(SubscribeRegistrationForm form);
}
