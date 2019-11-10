using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EtteplanTehtava.Models;
using Microsoft.EntityFrameworkCore;

namespace EtteplanTehtava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private MaintenanceContext _context;

        public UnitController(MaintenanceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/Unit/{id}
        /// </summary>
        /// <param name="id">Id of the target object from the url.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Maintenance>> GetUnit(int id)
        {
            Maintenance unit = await _context.Maintenance.FindAsync(id);

            if (unit == null)
                return NotFound();

            return unit;
        }

        /// <summary>
        /// POST: api/Unit
        /// </summary>
        /// <param name="maintenance">New maintenance object being posted.</param>
        [HttpPost]
        public async Task<ActionResult<Maintenance>> PostUnit(Maintenance maintenance)
        {
            try
            {
                // So you don't have to write date and time with Postman.
                maintenance.Added = DateTime.Now;
                maintenance.Updated = DateTime.Now;

                _context.Maintenance.Add(maintenance);
                await _context.SaveChangesAsync();
                return Content($"New unit with an ID {maintenance.Id} added successfully!");
            }
            catch (DbUpdateException e)
            {
                return Content($"Please take a look at your data and refer to the docs for proper names and types.\n{e.InnerException.Message}.");
            }
        }

        /// <summary>
        /// DELETE: api/Unit/{id}
        /// </summary>
        /// <param name="id">Id of the target object from the url.</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maintenance>> DeleteUnit(int id)
        {
            try
            {
                Maintenance unit = await _context.Maintenance.FindAsync(id);
                if (unit == null)
                    return NotFound();

                _context.Maintenance.Remove(unit);
                await _context.SaveChangesAsync();

                return Content($"{unit.Id}: {unit.Unit} removed successfully!");
            }
            catch (ArgumentNullException e)
            {
                return Content(e.Message);
            }
        }

        /// <summary>
        /// PUT: api/Unit/{id}
        /// </summary>
        /// <param name="id">Id of the target object from the url.</param>
        /// <param name="maintenance">Updated data of maintenance object.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<Maintenance>> UpdateUnit(int id, Maintenance maintenance)
        {
            try
            {
                Maintenance unit = await _context.Maintenance.FindAsync(id); ;

                if (unit != null)
                {
                    // So you don't have to write date and time with Postman.
                    maintenance.Updated = DateTime.Now;

                    // Prevents crashing of the server, cause we don't set id when casting maintenance parameter.
                    maintenance.Id = unit.Id;

                    _context.Entry(unit).CurrentValues.SetValues(maintenance);
                    await _context.SaveChangesAsync();
                    return Content($"{unit.Updated} Unit an ID {maintenance.Id} updated!\nNew data: {unit.Unit}\n{unit.Desc}\n{unit.Importance}\n{unit.State}");
                }

                return Content("Unit with an ID {id} not found!");
            }
            catch (ArgumentNullException e)
            {
                return Content(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Content($"Please take a look at your data and refer to the docs for proper names and types.\n{e.InnerException.Message}.");
            }
        }
    }
}