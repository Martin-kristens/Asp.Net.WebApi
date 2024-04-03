using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscribeRepository _subscribeRepository;
        private readonly ISubscribeService _subscriberService;
        public SubscribersController(ISubscribeRepository subscribeRepository, ISubscribeService subscriberService)
        {
            _subscribeRepository = subscribeRepository;
            _subscriberService = subscriberService;
        }


        #region CREATE
        [HttpPost]
        public async Task<IActionResult> Create(SubscribeRegistrationForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var subscriberExists = await _subscribeRepository.SubscriberExists(form.Email);
                if (subscriberExists)
                    return Conflict("There is already an subscriber with this email address");

                var subscriber = await _subscriberService.CreateSubscriber(form);
                if (subscriber)
                    return Created("You are now subscribed", subscriber);
                else
                    return StatusCode(500, "Failed to create subscriber");
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return NoContent();
            //if (!string.IsNullOrEmpty(email))
            //{
            //    if (!await _context.Subscribers.AnyAsync(x => x.Email == email))
            //    {
            //        try
            //        {
            //            var subscriberEntity = new SubscriberEntity { Email = email };
            //            _context.Subscribers.Add(subscriberEntity);
            //            await _context.SaveChangesAsync();

            //            return Created("", null);
            //        }
            //        catch (Exception)
            //        {
            //            return Problem("Unable to create subscription");
            //        }
            //    }

            //    return Conflict("A subscriber with the same email already exists");
            //}

            //return BadRequest();
        }

        #endregion

        #region READ
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{

        //    var subscribers = await _context.Subscribers.ToListAsync();
        //    if (subscribers.Count != 0)
        //    {
        //        return Ok(subscribers);
        //    }

        //    return NotFound();
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOne(int id)
        //{
        //    var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        //    if (subscriber != null)
        //    {
        //        return Ok(subscriber);
        //    }

        //    return NotFound();
        //}

        #endregion

        #region UPDATE
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOne(int id, string email)
        //{
        //    var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        //    if (subscriber != null)
        //    {
        //        subscriber.Email = email;
        //        _context.Subscribers.Update(subscriber);
        //        await _context.SaveChangesAsync();

        //        return Ok(subscriber);
        //    }

        //    return NotFound();
        //}

        #endregion

        #region DELETE
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        //    if (subscriber != null)
        //    {
        //        _context.Subscribers.Remove(subscriber);
        //        await _context.SaveChangesAsync();

        //        return Ok();
        //    }

        //    return NotFound();
        //}

        #endregion

    }
}
