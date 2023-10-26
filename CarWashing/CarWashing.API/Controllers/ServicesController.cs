using CarWashing.API.Data;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/api/services")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly DataContext _context;

    public ServicesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await _context.Services.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service == null)
        {
            return NotFound();
        }

        return service;
    }

    [HttpPost]
    public async Task<ActionResult<Service>> PostService(Service service)
    {
        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetService", new { id = service.ServiceId }, service);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutService(int id, Service service)
    {
        if (id != service.ServiceId)
        {
            return BadRequest();
        }

        _context.Entry(service).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceExists(id))
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

    private bool ServiceExists(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
        {
            return NotFound();
        }

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}

