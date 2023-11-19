using CarWashing.API.Data;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/api/histories")]
[ApiController]
public class HistoriesController : ControllerBase
{
    private readonly DataContext _context;

    public HistoriesController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<History>>> GetAsync()
    {
        return await _context.Histories.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<History>> GetAsync(int id)
    {
        var history = await _context.Histories.FindAsync(id);

        if (history == null)
        {
            return NotFound();
        }

        return history;
    }

    [HttpPost]
    public async Task<ActionResult<History>> PostAsync(History history)
    {
        _context.Histories.Add(history);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHistory", new { id = history.HistoryId }, history);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, History history)
    {
        if (id != history.HistoryId)
        {
            return BadRequest();
        }

        _context.Entry(history).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HistoryExists(id))
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
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var history = await _context.Histories.FindAsync(id);
        if (history == null)
        {
            return NotFound();
        }

        _context.Histories.Remove(history);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HistoryExists(int id)
    {
        return _context.Histories.Any(e => e.HistoryId == id);
    }
}

