using AssessmentApp.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly EventsDbContext _dbContext;

        public EventsController(EventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEvents(CancellationToken cancellationToken)
        {
            var events = await _dbContext.Events
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Address = e.Address
                })
                .ToListAsync(cancellationToken);

            return Ok(events);
        }


        // TODO: Create a GET endpoint for /api/events/{id}
        // Requirements:
        // - Accept the event ID as an int route parameter.
        // - Accept a CancellationToken parameter.
        // - Return Task<IActionResult>.
        // - Query _dbContext.Events.
        // - Filter the query to find the event with the matching ID.
        // - Project the Event into an EventDto.
        // - Include Id, Name, and Address in the DTO.
        // - Execute the query asynchronously
        // - If the event is found return the result
        // - If the event is NOT found, return NotFound()
        //
        // Expected routes:
        // GET /api/events/1
        // GET /api/events/5


    }
}
