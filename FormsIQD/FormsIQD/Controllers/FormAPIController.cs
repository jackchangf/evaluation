using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormsIQD;
using FormsIQD.Models;

namespace FormsIQD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormAPIController : ControllerBase
    {
        private readonly FormDbContext _context;

        public FormAPIController(FormDbContext context)
        {
            _context = context;
        }

        // GET: api/FormAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormModel>>> GetForms()
        {
            return await _context.Forms.ToListAsync();
        }

        // GET: api/FormAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormModel>> GetFormModel(int id)
        {
            var formModel = await _context.Forms.FindAsync(id);

            if (formModel == null)
            {
                return NotFound();
            }

            return formModel;
        }

        // PUT: api/FormAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormModel(int id, FormModel formModel)
        {
            if (id != formModel.id)
            {
                return BadRequest();
            }

            _context.Entry(formModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormModelExists(id))
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

        // POST: api/FormAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormModel>> PostFormModel([FromBody]  FormModel formModel)
        {
            _context.Forms.Add(formModel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/FormAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormModel(int id)
        {
            var formModel = await _context.Forms.FindAsync(id);
            if (formModel == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(formModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormModelExists(int id)
        {
            return _context.Forms.Any(e => e.id == id);
        }
    }
}
