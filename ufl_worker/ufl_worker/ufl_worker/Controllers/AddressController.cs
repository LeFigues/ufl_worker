using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _service;

        public AddressController(AddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _service.GetAllAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _service.GetByIdAsync(id);
            if (address == null)
                return NotFound();

            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressDto addressDto)
        {
            await _service.AddAsync(addressDto);
            return CreatedAtAction(nameof(GetById), new { id = addressDto.Id }, addressDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressDto addressDto)
        {
            if (id != addressDto.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(addressDto);
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
