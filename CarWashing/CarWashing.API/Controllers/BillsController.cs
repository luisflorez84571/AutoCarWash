using CarWashing.API.Data;
using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/api/bills")]
[ApiController]
public class BillsController : ControllerBase
{
    private readonly DataContext _context;

    public BillsController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bill>>> GetAsync()
    {
        return await _context.Bills.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bill>> GetAsync(int id)
    {
        var bill = await _context.Bills.FindAsync(id);

        if (bill == null)
        {
            return NotFound();
        }

        return bill;
    }

    [HttpPost]
    public async Task<ActionResult<Bill>> PostAsync(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBill", new { id = bill.BillId }, bill);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, Bill bill)
    {
        if (id != bill.BillId)
        {
            return BadRequest();
        }

        _context.Entry(bill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BillExists(id))
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
        var bill = await _context.Bills.FindAsync(id);
        if (bill == null)
        {
            return NotFound();
        }

        _context.Bills.Remove(bill);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BillExists(int id)
    {
        return _context.Bills.Any(e => e.BillId == id);
    }
}
