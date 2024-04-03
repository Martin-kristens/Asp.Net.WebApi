using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System.Diagnostics;

namespace Infrastructure.Services;

public class SubscribeService : ISubscribeService
{
    private readonly ISubscribeRepository _subscribeRepository;

    public SubscribeService(ISubscribeRepository subscribeRepository)
    {
        _subscribeRepository = subscribeRepository;
    }

    public async Task<bool> CreateSubscriber(SubscribeRegistrationForm form)
    {
        try
        {
            bool subscriberAlreadyExists = await _subscribeRepository.SubscriberExists(form.Email);
            if (subscriberAlreadyExists)
            {
                return subscriberAlreadyExists;
            }
            else
            {
                var subscriberEntity = new SubscriberEntity { Email = form.Email };
                return await _subscribeRepository.CreateSubscriber(subscriberEntity);
            }

            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
