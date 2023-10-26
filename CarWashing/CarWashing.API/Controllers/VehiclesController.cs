using CarWashing.API.Data;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/api/vehicles")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly DataContext _context;

    public VehiclesController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return vehicle;
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleId }, vehicle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.VehicleId)
        {
            return BadRequest();
        }

        _context.Entry(vehicle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehicleExists(id))
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
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VehicleExists(int id)
    {
        return _context.Vehicles.Any(e => e.VehicleId == id);
    }
}