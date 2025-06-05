using BookManager.App.Models.Books;
using BookManager.App.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Post(CreateBookInputModel model)
        {
            var result = _bookService.Insert(model);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet("PorId/{id}")]
        public IActionResult GetById(int id) 
        {
            var result = _bookService.GetById(id);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UpdateBookInputModel model) 
        {
            var result = _bookService.Update(id, model);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
