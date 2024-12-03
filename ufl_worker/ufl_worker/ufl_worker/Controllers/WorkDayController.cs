using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WorkDayController : ControllerBase
    {
        private readonly WorkDayService _service;

        public WorkDayController(WorkDayService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workDays = await _service.GetAllAsync();
            return Ok(workDays);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workDay = await _service.GetByIdAsync(id);
            if (workDay == null)
                return NotFound();

            return Ok(workDay);
        }

        [HttpPost]
        public async Task<IActionResult> Add(WorkDayDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WorkDayDto dto)
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

        //---------------------------------------------------------------------------------------
        [HttpPost("start")]
        public async Task<IActionResult> StartWorkDay([FromBody] StartWorkDayDto dto)
        {
            try
            {
                await _service.StartWorkDayAsync(dto);
                return Ok(new { message = "Work day started successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("end")]
        public async Task<IActionResult> EndWorkDay([FromBody] EndWorkDayDto dto)
        {
            try
            {
                await _service.EndWorkDayAsync(dto);
                return Ok(new { message = "Work day ended successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("validate")]
        public async Task<IActionResult> ValidateWorkDay([FromBody] ValidateWorkDayDto dto)
        {
            try
            {
                await _service.ValidateWorkDayAsync(dto);
                var message = dto.IsCounted ? "Work day marked as valid." : "Work day marked as invalid.";
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
