using CarWashing.API.Data;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly DataContext _context;

    public ClientsController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client client)
    {
        _context.Clients.Add(client);
        try
        {

            await _context.SaveChangesAsync();
            return Ok(client);
        }
        catch (DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
            {
                return BadRequest("Ya existe un cliente con el mismo nombre.");
            }
            else
            {
                return BadRequest(dbUpdateException.InnerException.Message);
            }
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }

    }

    [HttpPut]
    public async Task<ActionResult> Put(Client client)
    {
        _context.Update(client);
        try
        {
            await _context.SaveChangesAsync();
            return Ok(client);
        }
        catch (DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
            {
                return BadRequest("Ya existe un registro con el mismo nombre.");
            }
            else
            {
                return BadRequest(dbUpdateException.InnerException.Message);
            }
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClientExists(int id)
    {
        return _context.Clients.Any(e => e.ClientId == id);
    }
}

