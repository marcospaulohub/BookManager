using BookManager.App.Models.Users;
using BookManager.App.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var result = _userService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            if(!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("/api/users")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

    }
}
