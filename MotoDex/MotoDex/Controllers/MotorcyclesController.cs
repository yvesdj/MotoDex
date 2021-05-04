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
    public class MotorcyclesController : ControllerBase
    {
        private readonly MotorcyclesContext _context;

        public MotorcyclesController(MotorcyclesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateMotorcycle([FromBody] Motorcycle newMotorcycle)
        {
            _context.Motorcycles.Add(newMotorcycle);
            _context.SaveChanges();

            return Created("", newMotorcycle);
        }

        [HttpGet]
        public IEnumerable<Motorcycle> GetAllMotorcycles()
        {
            return _context.Motorcycles.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetMotorcycle(int id)
        {
            Motorcycle motorcycle = _context.Motorcycles
                .Include(moto => moto.Make)
                .Include(moto => moto.Engine)
                .Include(moto => moto.MotorcycleFrontTyres)
                //.Include(moto => moto.RearTyre)
                .Include(moto => moto.FrontBreakPads)
                .Include(moto => moto.RearBreakPads)
                .SingleOrDefault(motorcycle => motorcycle.Id == id);

            if (motorcycle == null)
                return NotFound();

            return Ok(motorcycle);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateMotorcycle(int id, [FromBody] Motorcycle upMotorcycle)
        {
            Motorcycle motorcycle = _context.Motorcycles.Find(id);
            if (motorcycle == null)
            {
                return NotFound();
            }
            else
            {
                motorcycle.Make = upMotorcycle.Make;
                motorcycle.Model = upMotorcycle.Model;
                motorcycle.Engine = upMotorcycle.Engine;
                motorcycle.FinalDrive = upMotorcycle.FinalDrive;
                motorcycle.MotorcycleFrontTyres = upMotorcycle.MotorcycleFrontTyres;
                //motorcycle.RearTyre = upMotorcycle.RearTyre;
                motorcycle.FrontBreakPads = upMotorcycle.FrontBreakPads;
                motorcycle.RearBreakPads = upMotorcycle.RearBreakPads;

                _context.SaveChanges();
                return Created("", motorcycle);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteMotorcycle(int id)
        {
            Motorcycle motorcycle = _context.Motorcycles.Find(id);
            if (motorcycle == null)
            {
                return NotFound();
            }
            else
            {
                _context.Motorcycles.Remove(motorcycle);

                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
