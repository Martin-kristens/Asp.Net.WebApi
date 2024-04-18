using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                    return Conflict("You have already been subscribed");

                var subscriber = await _subscriberService.CreateSubscriberAsync(form);
                if (subscriber)
                    return Created("You are now subscribed", subscriber);
                else
                    return StatusCode(500, "Failed to create subscriber");
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return NoContent();
        }
        #endregion

        #region READ
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _subscriberService.GetAllSubscribersAsync();
                    if (result != null)
                        return Ok(result);
                    else 
                        return NotFound("No subscribers was found");
                }
                return BadRequest();
            }
            catch (Exception ex) {Debug.WriteLine(ex.Message); }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subscriber = await _subscriberService.GetOneSubscriberAsync(email);
                    if (subscriber != null)
                        return Ok(subscriber);
                    else
                        return NotFound($"No subscriber was found with Email {email}.");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex){Debug.WriteLine(ex.Message);}
            return StatusCode(500);
        }

        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updated = await _subscriberService.UpdateSubscriberAsync(id, email);
                    if (updated)                 
                        return NoContent();                 
                    else
                        return NotFound();
                }
                return BadRequest(ModelState);
               
            }
            catch (Exception ex){Debug.WriteLine(ex.Message); }
            return StatusCode(500);

        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var deleteSubscriber = await _subscriberService.DeleteSubscriberAsync(email);
                    if (deleteSubscriber)
                        return NoContent();

                    else 
                        return NotFound();
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex){Debug.WriteLine(ex.Message); }
            return StatusCode(500);
        } 
        #endregion

    }
}
