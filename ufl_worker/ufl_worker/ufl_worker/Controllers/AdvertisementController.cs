using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdvertisementController : ControllerBase
    {
        private readonly AdvertisementService _service;

        public AdvertisementController(AdvertisementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var advertisements = await _service.GetAllAsync();
            return Ok(advertisements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var advertisement = await _service.GetByIdAsync(id);
            if (advertisement == null)
                return NotFound();

            return Ok(advertisement);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdvertisementDto advertisementDto)
        {
            await _service.AddAsync(advertisementDto);
            return CreatedAtAction(nameof(GetById), new { id = advertisementDto.Id }, advertisementDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AdvertisementDto advertisementDto)
        {
            if (id != advertisementDto.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(advertisementDto);
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
