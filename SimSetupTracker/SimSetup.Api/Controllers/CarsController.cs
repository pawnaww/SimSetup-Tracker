using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimSetup.Api.Data;
using SimSetup.Shared.Models;

namespace SimSetup.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CarsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<CarsController> _logger;

    public CarsController(AppDbContext context, ILogger<CarsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Pobiera listę wszystkich dostępnych samochodów.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        return await _context.Cars
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Pobiera szczegóły samochodu na podstawie podanego ID.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _context.Cars
            .Include(c => c.Setups)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (car == null)
        {
            _logger.LogWarning("Samochód o Id {CarId} nie został znaleziony.", id);
            return NotFound(new { message = $"Samochód o ID {id} nie istnieje." });
        }

        return Ok(car);
    }

    /// <summary>
    /// Dodaje nowy samochód do bazy danych.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Car>> CreateCar([FromBody] Car car)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Dodano nowy samochód: {Brand} {Model} (ID: {CarId})", car.Brand, car.Model, car.Id);

        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
    }

    /// <summary>
    /// Aktualizuje dane istniejącego samochodu.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
    {
        if (id != car.Id)
        {
            return BadRequest(new { message = "Identyfikator w ścieżce nie zgadza się z ID obiektu." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(car).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Zaktualizowano samochód o ID: {CarId}", id);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CarExistsAsync(id))
            {
                return NotFound(new { message = $"Samochód o ID {id} nie został odnaleziony." });
            }
            throw;
        }

        return NoContent();
    }

    /// <summary>
    /// Usuwa samochód z bazy danych wraz z powiązanymi konfiguracjami (kaskadowo).
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound(new { message = $"Samochód o ID {id} nie został odnaleziony." });
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Usunięto samochód o ID: {CarId}", id);

        return NoContent();
    }

    private async Task<bool> CarExistsAsync(int id)
    {
        return await _context.Cars.AnyAsync(e => e.Id == id);
    }
}
