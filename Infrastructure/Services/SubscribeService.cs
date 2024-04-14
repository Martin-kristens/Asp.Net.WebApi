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

    #region CREATE
    public async Task<bool> CreateSubscriberAsync(SubscribeRegistrationForm form)
    {
        try
        {
            bool subscriberAlreadyExists = await _subscribeRepository.SubscriberExists(form.Email);
            if (subscriberAlreadyExists)
                return subscriberAlreadyExists;
            else
            {
                var subscriberEntity = new SubscriberEntity { Email = form.Email };
                return await _subscribeRepository.CreateSubscriber(subscriberEntity);
            }            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
    #endregion

    #region READ
    public async Task<IEnumerable<SubscriberEntity>> GetAllSubscribersAsync()
    {
        try
        {
            return await _subscribeRepository.GetAllSubscribersAsync();
        }
        catch (Exception ex){ Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<SubscriberEntity> GetOneSubscriberAsync(string email)
    {
        try
        {
            var subscriberExists = await _subscribeRepository.GetOneSubscriberByEmail(email);
            if (subscriberExists != null)
                return subscriberExists;
        }
        catch (Exception ex){ Debug.WriteLine(ex.Message); }
        return null!;
    }
    #endregion

    #region UPDATE
    public async Task<bool> UpdateSubscriberAsync(int id, string email)
    {
        try
        {
            var subscriber = await _subscribeRepository.GetOneSubscriberByEmail(email);
            if ( subscriber != null )
            {
                subscriber.Email = email;
                return await _subscribeRepository.UpdateSubscriberAsync(subscriber);
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex){Debug.WriteLine(ex.Message); }
        return false;
    }
    #endregion

    #region DELETE
    public async Task<bool> DeleteSubscriberAsync(string email)
    {
        try
        {
            var subscriberToDelete = await _subscribeRepository.GetOneSubscriberByEmail(email);
            if (subscriberToDelete != null)
                return await _subscribeRepository.DeleteSubscriberAsync(subscriberToDelete);
        }
        catch (Exception ex){Debug.WriteLine(ex.Message); }
        return false;
    }
    #endregion
}
