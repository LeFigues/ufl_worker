using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BusinessController : ControllerBase
    {
        private readonly BusinessService _service;

        public BusinessController(BusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var businesses = await _service.GetAllAsync();
            return Ok(businesses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var business = await _service.GetByIdAsync(id);
            if (business == null)
                return NotFound();

            return Ok(business);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BusinessDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BusinessDto dto)
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
