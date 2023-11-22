using CarWashing.API.Data;
using CarWashing.API.Helpers;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("/api/histories")]

public class HistoriesController : ControllerBase
{
    private readonly DataContext _context;

    public HistoriesController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var queryable = _context.Histories
            .Include(x => x.Histories)
            .AsQueryable();

        return Ok(await queryable
            .OrderBy(x => x.Fecha)
            .Paginate(pagination)
            .ToListAsync());
    }

    [HttpGet("totalPages")]
    public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
    {
        var queryable = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) ||
                                             x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
        }

        double count = await queryable.CountAsync();
        double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
        return Ok(totalPages);
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

