using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Model;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly HospitalDbContext _context;

    public PatientsController(HospitalDbContext context)
    {
        _context = context;
    }

    // GET: api/patients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        return await _context.Patients.Include(p => p.Department).ToListAsync();
    }

    // GET: api/patients/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _context.Patients.Include(p => p.Department).FirstOrDefaultAsync(p => p.Id == id);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    // POST: api/patients
    [HttpPost]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
    }

    // PUT: api/patients/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, Patient patient)
    {
        if (id != patient.Id)
        {
            return BadRequest();
        }

        _context.Entry(patient).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/patients/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
