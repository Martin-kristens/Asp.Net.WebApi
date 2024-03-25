using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        #region CREATE
        [HttpPost]
        public IActionResult Create(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {

            }

            return BadRequest();
        }

        #endregion

        #region READ
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetOne()
        {
            return Ok();
        }

        #endregion

        #region UPDATE
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        #endregion

        #region DELETE
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        #endregion

    }
}
