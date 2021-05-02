using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoDex.Db;
using MotoDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MotorcycleMakeController : ControllerBase
    {
        private readonly MotorcyclesContext _context;

        public MotorcycleMakeController(MotorcyclesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateMotoMake([FromBody] MotorcycleMake newMake)
        {
            _context.MotorcycleMakes.Add(newMake);
            _context.SaveChanges();

            return Created("", newMake);
        }

        [HttpGet]
        public IEnumerable<MotorcycleMake> GetAllMotoMakes()
        {
            return _context.MotorcycleMakes.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetMotoMake(int id)
        {
            MotorcycleMake make = _context.MotorcycleMakes
                .Include(make => make.Motorcycles)
                .SingleOrDefault(make => make.Id == id);

            if (make == null)
                return NotFound();

            return Ok(make);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateMotoMake(int id, [FromBody] MotorcycleMake upMake)
        {
            MotorcycleMake make = _context.MotorcycleMakes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            else
            {
                make.Name = upMake.Name;
                make.Summary = upMake.Summary;
                make.Motorcycles = upMake.Motorcycles;

                _context.SaveChanges();
                return Created("", make);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteMotoMake(int id)
        {
            MotorcycleMake make = _context.MotorcycleMakes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            else
            {
                _context.MotorcycleMakes.Remove(make);

                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
