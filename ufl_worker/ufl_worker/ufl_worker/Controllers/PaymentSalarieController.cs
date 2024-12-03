using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentSalarieController : ControllerBase
    {
        private readonly PaymentSalarieService _service;

        public PaymentSalarieController(PaymentSalarieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paymentSalaries = await _service.GetAllAsync();
            return Ok(paymentSalaries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentSalarie = await _service.GetByIdAsync(id);
            if (paymentSalarie == null)
                return NotFound();

            return Ok(paymentSalarie);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentSalarieDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaymentSalarieDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
