using ApiMotorFila.Context;
using ApiMotorFila.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMotorFila.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MotorController : ControllerBase
{
    private readonly MDbContext motorDbContext;

    public MotorController(MDbContext motorDbContext)
    {
        this.motorDbContext = motorDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Motor>>> GetMotor()
    {
        var motors = await motorDbContext.Motors.ToListAsync();
        return Ok(motors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Motor>> GetMotor(int id)
    {
        var motor = await motorDbContext.Motors.FindAsync(id);

        if (motor == null)
        {
            return NotFound();
        }

        return Ok(motor);
    }

    [HttpPost]
    public async Task<ActionResult<Motor>> CreateMotor(MotorDto motorDto)
    {
        var motor = new Motor
        {
            Name = motorDto.Name,
            Speed = motorDto.Speed,
            Meter = motorDto.Meter,
            State = motorDto.State
        };

        motorDbContext.Motors.Add(motor);
        await motorDbContext.SaveChangesAsync();

        return CreatedAtAction("GetMotor", new { id = motor.Id }, motor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMotor(int id, MotorDto motorDto)
    {
        var motor = await motorDbContext.Motors.FindAsync(id);
        if (motor == null)
        {
            return NotFound();
        }

        motor.Name = motorDto.Name;
        motor.Speed = motorDto.Speed;
        motor.Meter = motorDto.Meter;
        motor.State = motorDto.State;

        motorDbContext.Entry(motor).State = EntityState.Modified;

        try
        {
            await motorDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MotorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMotor(int id)
    {
        var motor = await motorDbContext.Motors.FindAsync(id);
        if (motor == null)
        {
            return NotFound();
        }

        motorDbContext.Remove(motor);
        await motorDbContext.SaveChangesAsync();

        return NoContent();
    }


    private bool MotorExists(int id)
    {
        return motorDbContext.Motors.Any(m => m.Id == id);
    }

}
