using BookManager.App.Models.Loans;
using BookManager.App.Services.Loans;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/Loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public IActionResult Post(CreateLoanInputModel model)
        {
            var result = _loanService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, model);
        }

        [HttpGet("PorId/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _loanService.GetById(id);

            if(!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _loanService.GetAll();
            if(!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }
    }
}
