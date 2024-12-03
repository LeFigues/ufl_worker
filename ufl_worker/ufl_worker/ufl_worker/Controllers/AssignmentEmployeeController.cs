using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ufl_worker.Application.DTOs;
using ufl_worker.Application.Services;

namespace ufl_worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AssignmentEmployeeController : ControllerBase
    {
        private readonly AssignmentEmployeeService _service;

        public AssignmentEmployeeController(AssignmentEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assignmentEmployees = await _service.GetAllAsync();
            return Ok(assignmentEmployees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assignmentEmployee = await _service.GetByIdAsync(id);
            if (assignmentEmployee == null)
                return NotFound();

            return Ok(assignmentEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AssignmentEmployeeDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AssignmentEmployeeDto dto)
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
