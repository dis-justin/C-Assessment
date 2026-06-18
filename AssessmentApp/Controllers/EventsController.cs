using AssessmentApp.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        // TODO: Add a private readonly field for the database context.
        // Requirements:
        // - Create a private readonly field named _dbContext.
        // - The field type should be EventsDbContext.



        // TODO: Add a constructor for EventsController.
        // Requirements:
        // - The constructor should be public.
        // - Accept an EventsDbContext parameter named dbContext.
        // - Use constructor dependency injection.
        // - Assign the incoming dbContext parameter to the private _dbContext field.



        // TODO: Create a GET endpoint for /api/events
        // Requirements:
        // - Return Task<IActionResult>.
        // - Accept a CancellationToken parameter.
        // - Query _dbContext.Events.
        // - Sort the results by event name.
        // - Project each Event into an EventDto.
        // - Include Id, Name, and Address in the DTO.
        // - Execute the query asynchronously
        // - Return the result
        //
        // Expected route:
        // GET /api/events



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
