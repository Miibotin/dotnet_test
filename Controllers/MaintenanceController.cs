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
    public class MaintenanceController : ControllerBase
    {
        private MaintenanceContext _context;

        public MaintenanceController(MaintenanceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IOrderedQueryable<Maintenance> GetAll()
        {
            return _context.MaintenanceUnit.OrderBy(a => a.Id);
        }

        [HttpPost]
        public async Task<ActionResult<Maintenance>> PostUnit(Maintenance maintenance)
        {
            try
            {
                maintenance.Added = DateTime.Now; // So you don't have to write date and time with Postman.
                _context.MaintenanceUnit.Add(maintenance);
                await _context.SaveChangesAsync();
                return Content($"New unit with an ID {maintenance.Id} added successfully!");
            }
            catch(DbUpdateException e)
            {
                return Content($"Please take a look at your data and refer to the docs for proper names and types.\n{e.InnerException.Message}.");
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Maintenance>> DeleteUnit(int id)
        {
            try
            {
                Maintenance unit = _context.MaintenanceUnit.SingleOrDefault(p => p.Id == id);
                _context.MaintenanceUnit.Remove(unit);
                await _context.SaveChangesAsync();
                return Content($"{unit.Id}: {unit.Unit} removed successfully!");
            }
            catch (ArgumentNullException e)
            {
                return Content(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Maintenance>> UpdateUnit(int id, Maintenance maintenance)
        {
            try
            {
                Maintenance unit = _context.MaintenanceUnit.SingleOrDefault(p => p.Id == id);

                if (unit != null)
                {
                    maintenance.Added = DateTime.Now; // So you don't have to write date and time with Postman.
                    maintenance.Id = unit.Id; // Prevents crashing of the server, cause we don't set id when casting maintenance parameter.
                    _context.Entry(unit).CurrentValues.SetValues(maintenance);
                    await _context.SaveChangesAsync();
                    return Content($"Unit an ID {maintenance.Id} updated! New data:\n{unit.Unit}\n{unit.Desc}\n{unit.MaintClass}\n{unit.State}");
                }

                return Content("Unit with an ID {id} not found!");
            }
            catch (ArgumentNullException e)
            {
                return Content(e.Message);
            }
            catch(DbUpdateException e)
            {
                return Content($"Please take a look at your data and refer to the docs for proper names and types.\n{e.InnerException.Message}.");
            }
        }
    }
}