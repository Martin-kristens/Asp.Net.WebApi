using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class SubscribersRepository : ISubscribeRepository
{
    private readonly DataContext _context;

    public SubscribersRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> SubscriberExists(string email)
    {
        try
        {
            return await _context.Subscribers.AnyAsync(x => x.Email == email);
        }
        catch (Exception ex) { Debug.WriteLine("Something went wrong" + ex.Message); }
        return false;
    }

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

    public Task<bool> DeleteSubscriber(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<SubscriberEntity>> GetAllSubscribersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SubscriberEntity> GetOneSubscriberById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateSubscriber(SubscriberEntity subscriber)
    {
        throw new NotImplementedException();
    }
}
