using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdvertisementEmployeeController : ControllerBase
    {
        private readonly AdvertisementEmployeeService _service;

        public AdvertisementEmployeeController(AdvertisementEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var advertisementEmployees = await _service.GetAllAsync();
            return Ok(advertisementEmployees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var advertisementEmployee = await _service.GetByIdAsync(id);
            if (advertisementEmployee == null)
                return NotFound();

            return Ok(advertisementEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdvertisementEmployeeDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AdvertisementEmployeeDto dto)
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
