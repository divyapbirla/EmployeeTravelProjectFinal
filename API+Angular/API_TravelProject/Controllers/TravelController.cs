using API_TravelProject.Models;
using API_TravelProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TravelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelRepository _repository;

        public TravelController(ITravelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelRequest>>> Get()
        {
            IEnumerable<TravelRequest> travelRequests = await _repository.GetTravelRequests();
            if (travelRequests != null)
            {
                return Ok(travelRequests);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TravelRequest>> GetTravelRequestById(int id)
        {
            TravelRequest travelRequest = await _repository.GetTravelRequestById(id);

            if (travelRequest != null)
            {
                return Ok(travelRequest);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TravelRequest travelRequest)
        {
            if (travelRequest == null)
            {
                return BadRequest();
            }

            travelRequest.Approve = "Pending";
            travelRequest.BookingStatus = "Pending";
            travelRequest.CurrentStatus = "Open";

            await _repository.AddTravelRequest(travelRequest);
            return CreatedAtAction(nameof(GetTravelRequestById), new { id = travelRequest.RequestId }, travelRequest);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTravelRequest(int id, [FromBody] TravelRequest updatedTravelRequest)
        {
            if (updatedTravelRequest == null || id != updatedTravelRequest.RequestId)
            {
                return BadRequest();
            }

            TravelRequest existingTravelRequest = await _repository.GetTravelRequestById(id);

            if (existingTravelRequest == null)
            {
                return NotFound();
            }

            existingTravelRequest.FromDestination = updatedTravelRequest.FromDestination;
            existingTravelRequest.ToDestination = updatedTravelRequest.ToDestination;
            existingTravelRequest.Date1 = updatedTravelRequest.Date1;
            existingTravelRequest.Approve = updatedTravelRequest.Approve;
            existingTravelRequest.BookingStatus = updatedTravelRequest.BookingStatus;
            existingTravelRequest.CurrentStatus = updatedTravelRequest.CurrentStatus;

            await _repository.UpdateTravelRequest(existingTravelRequest, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTravelRequest(int id)
        {
            TravelRequest? travelRequest = await _repository.GetTravelRequestById(id);
            if (travelRequest != null)
            {
                await _repository.DeleteTravelRequest(id);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("Approve/{id}")]
        public async Task<ActionResult> ApproveTravelRequest(int id, [FromBody] string status)
        {
            await _repository.ApproveTravelRequestAsync(id, status);
            return NoContent();
        }

        [HttpPut("Book/{id}")]
        public async Task<ActionResult> BookTravelRequest(int id, [FromBody] string status)
        {
            await _repository.BookTravelRequestAsync(id, status);
            return NoContent();
        }


    }
}
