using BookManager.App.Models.Authors;
using BookManager.App.Services.Authors;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Post(CreateAuthorInputModel model)
        {
            var result = _authorService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet("PorId/{id}")]
        public IActionResult GetById(int id) 
        {
            var result = _authorService.GetById(id);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _authorService.GetAll();

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UpdateAuthorInputModel model)
        {
            var result = _authorService.Update(id, model);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
