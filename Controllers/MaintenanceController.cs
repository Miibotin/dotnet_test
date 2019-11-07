using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EtteplanTehtava.Models;

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
            var item = _context.MaintenanceUnit.OrderBy(a => a.Id);

            return item;
        }
    }
}