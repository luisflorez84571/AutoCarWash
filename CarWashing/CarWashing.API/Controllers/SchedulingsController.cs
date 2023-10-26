using CarWashing.API.Data;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/api/chedulings")]
[ApiController]
public class SchedulingsController : ControllerBase
{
    private readonly DataContext _context;

    public SchedulingsController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Scheduling>>> GetSchedulings()
    {
        return await _context.Schedulings.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Scheduling>> GetScheduling(int id)
    {
        var scheduling = await _context.Schedulings.FindAsync(id);

        if (scheduling == null)
        {
            return NotFound();
        }

        return scheduling;
    }

    [HttpPost]
    public async Task<ActionResult<Scheduling>> PostScheduling(Scheduling scheduling)
    {
        _context.Schedulings.Add(scheduling);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetScheduling", new { id = scheduling.SchedulingId }, scheduling);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutScheduling(int id, Scheduling scheduling)
    {
        if (id != scheduling.SchedulingId)
        {
            return BadRequest();
        }

        _context.Entry(scheduling).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SchedulingExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScheduling(int id)
    {
        var scheduling = await _context.Schedulings.FindAsync(id);
        if (scheduling == null)
        {
            return NotFound();
        }

        _context.Schedulings.Remove(scheduling);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SchedulingExists(int id)
    {
        return _context.Schedulings.Any(e => e.SchedulingId == id);
    }
}
