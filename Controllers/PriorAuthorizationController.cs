using Microsoft.AspNetCore.Mvc;
using PriorAuthPrototype.Models;
using PriorAuthPrototype.Dtos; // Add this!!
using PriorAuthPrototype.Data;

namespace PriorAuthPrototype.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriorAuthorizationController : ControllerBase
    {
        private readonly IPriorAuthorizationService _service;

        public PriorAuthorizationController(IPriorAuthorizationService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<List<PriorAuthorizationRequestDto>>> GetAllRequests()
        {
            var requests = await _service.GetAllRequestsAsync();
            return Ok(requests);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorAuthorizationRequestDto>> GetRequestById(int id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        // CREATE (POST)
        [HttpPost]
        public async Task<ActionResult<PriorAuthorizationRequestDto>> CreateRequest(PriorAuthorizationRequest request)
        {
            var createdRequest = await _service.CreateRequestAsync(request);
            return CreatedAtAction(nameof(GetRequestById), new { id = createdRequest.Id }, createdRequest);
        }

        // UPDATE (PUT)
        [HttpPut("{id}")]
        public async Task<ActionResult<PriorAuthorizationRequestDto>> UpdateRequest(int id, PriorAuthorizationRequest updatedRequest)
        {
            var updated = await _service.UpdateRequestAsync(id, updatedRequest);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var success = await _service.DeleteRequestAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
