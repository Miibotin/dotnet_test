using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtteplanTehtava.Models;

namespace EtteplanTehtava.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly MaintenanceContext _context;

        public MaintenanceController(MaintenanceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/Maintenance
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> ListUnits()
        {
            var units = await _context.Maintenance.ToListAsync();

            if (units == null)
                return NotFound();

            return units;
        }

        /// <summary>
        /// GET: api/Maintenance/{unit}
        /// </summary>
        /// <param name="unit">Targetted name variable from the url that is needed to find certain units.</param>
        [HttpGet("{unit}")]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetUnits(string unit)
        {
            var units = await _context.Maintenance.Where(p => p.Unit == unit).ToListAsync();

            if (units == null)
                return NotFound();

            return units;
        }

    }
}
