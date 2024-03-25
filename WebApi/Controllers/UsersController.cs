using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private static List<UserModel> _users = 
        [
            new UserModel {FirstName = "Martin", LastName = "Kristensen", Email = "martin@domain.se"},
            new UserModel {FirstName = "Marika", LastName = "Kristensen", Email = "marika@domain.se"},
        ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_users);
    }

    [HttpGet("{email}")]
    public IActionResult GetOne(string email)
    {
        var user = _users.First(x => x.Email == email);
        if (user != null)
        {
            return Ok(user);
        }

        return NotFound();
        
    }

    [HttpPost]
    public IActionResult CreateOne(UserRequestModel model)
    {
        if (ModelState.IsValid)
        {
            var userModel = new UserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            return Created("", userModel);
        }

        return BadRequest(model);
    }
}
