using CasaCue.Shared.Models;
using CasaCue.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;

namespace CasaCue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaitlistController(WaitlistService service) : ControllerBase
    {
        private readonly WaitlistService _service = service;

        [HttpGet]
        public IActionResult GetWaitlist()
        {
            Log.Information("Fetching the entire waitlist.");
            var waitlist = _service.GetWaitlist();
            return Ok(waitlist);
        }

        

        [HttpPost]
        public IActionResult AddGuest([FromBody] Guest guest)
        {
            if (guest.Id == Guid.Empty)
            {
                Log.Warning("Attempt to add a guest with an empty ID.");
                return BadRequest("Guest ID is required.");
            }

            _service.AddGuest(guest.Id, guest.Name, guest.GroupSize);
            var addedGuest = _service.GetGuestById(guest.Id); // Hole das gespeicherte Guest-Objekt
            Log.Information("Guest {Name} added with ID {Id} and group size {GroupSize}.", guest.Name, guest.Id, guest.GroupSize);

            return CreatedAtAction(nameof(GetGuestById), new { id = guest.Id }, addedGuest);
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveGuest(Guid id)
        {
            var guest = _service.GetGuestById(id);
            if (guest == null)
            {
                Log.Warning("Attempt to remove a non-existent guest with ID {Id}.", id);
                return NotFound();
            }

            _service.RemoveGuest(id);
            Log.Information("Guest {Name} with ID {Id} removed from the waitlist.", guest.Name, id);

            return NoContent();
        }

        // GET by ID
        [HttpGet("id/{id}")]
        public IActionResult GetGuestById(Guid id)
        {
            Log.Information("Fetching guest with ID {Id}.", id);
            var guest = _service.GetGuestById(id);
            if (guest == null)
            {
                Log.Warning("Guest with ID {Id} not found.", id);
                return NotFound();
            }

            return Ok(guest);
        }

        // GET by Name
        [HttpGet("name/{name}")]
        public IActionResult GetGuestsByName(string name)
        {
            Log.Information("Fetching guests with name {Name}.", name);
            var guests = _service.GetGuestsByName(name);
            if (guests == null || !guests.Any())
            {
                Log.Warning("No guests found with name {Name}.", name);
                return NotFound();
            }

            return Ok(guests);
        }

        // GET by QueuePosition
        [HttpGet("queueposition/{queuePosition}")]
        public IActionResult GetGuestByQueuePosition(int queuePosition)
        {
            Log.Information("Fetching guest at queue position {QueuePosition}.", queuePosition);
            var guest = _service.GetGuestByPosition(queuePosition);
            if (guest == null)
            {
                Log.Warning("No guest found at queue position {QueuePosition}.", queuePosition);
                return NotFound();
            }
            return Ok(guest);
        }
        
        [HttpDelete("cleanup/{id}")]
        public IActionResult CleanupGuest(Guid id)
        {
            var guest = _service.GetGuestById(id);
            if (guest != null)
            {
                _service.RemoveGuest(id);
                return Ok(new { Message = $"Guest with ID {id} deleted." });
            }
            return NotFound(new { Message = $"Guest with ID {id} not found." });
        }


    }
}
