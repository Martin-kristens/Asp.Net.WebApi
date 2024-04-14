using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class SubscribersRepository(DataContext context) : ISubscribeRepository
{
    private readonly DataContext _context = context;

    #region EXISTS
    public async Task<bool> SubscriberExists(string email)
    {
        try
        {
            return await _context.Subscribers.AnyAsync(x => x.Email == email);
        }
        catch (Exception ex) { Debug.WriteLine("Something went wrong" + ex.Message); }
        return false;
    }
    #endregion


    #region CREATE
    public async Task<bool> CreateSubscriber(SubscriberEntity subscriber)
    {
        try
        {
            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { Debug.WriteLine("Something went wrong" + ex.Message); }
        return false;
    }
    #endregion

    #region READ
    public async Task<ICollection<SubscriberEntity>> GetAllSubscribersAsync()
    {
        try
        {
            return await _context.Subscribers.ToListAsync();
        }
        catch (Exception ex){Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<SubscriberEntity> GetOneSubscriberByEmail(string email)
    {
        try
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber != null)
                return subscriber;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    #endregion

    #region UPDATE
    public async Task<bool> UpdateSubscriberAsync(SubscriberEntity subscriber)
    {
        try
        {           
            _context.Subscribers.Update(subscriber);
            await _context.SaveChangesAsync();

            return true;          
        }
        catch (Exception ex){Debug.WriteLine(ex.Message); }
        return false;
    }
    #endregion

    #region DELETE
    public async Task<bool> DeleteSubscriberAsync(SubscriberEntity subscriber)
    {
        try
        {
            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex){Debug.WriteLine(ex.Message);}
        return false;
    }

    #endregion

}
