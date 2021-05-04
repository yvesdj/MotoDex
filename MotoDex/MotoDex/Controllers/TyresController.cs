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
    public class TyresController : ControllerBase
    {
        private readonly MotorcyclesContext _context;

        public TyresController(MotorcyclesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateTyres([FromBody] Tyre newTyre)
        {
            _context.Tyres.Add(newTyre);
            _context.SaveChanges();

            return Created("", newTyre);
        }

        [HttpGet]
        public IEnumerable<Tyre> GetAllTyres()
        {
            return _context.Tyres.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetTyre(int id)
        {
            Tyre tyre = _context.Tyres
                .Include(tyre => tyre.MotorcycleFrontTyres)
                    .ThenInclude(mft => mft.Motorcycle)
                        .ThenInclude(moto => moto.Engine)
                .Include(tyre => tyre.MotorcycleFrontTyres)
                    .ThenInclude(mft => mft.Motorcycle)
                        .ThenInclude(moto => moto.FrontBreakPads)
                .Include(tyre => tyre.MotorcycleFrontTyres)
                    .ThenInclude(mft => mft.Motorcycle)
                        .ThenInclude(moto => moto.RearBreakPads)
                .SingleOrDefault(tyre => tyre.Id == id);

            if (tyre == null)
                return NotFound();

            return Ok(tyre);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateTyre(int id, [FromBody] Tyre upMotorcycle)
        {
            Tyre tyre = _context.Tyres.Find(id);
            if (tyre == null)
            {
                return NotFound();
            }
            else
            {
                tyre.Make = upMotorcycle.Make;
                tyre.Model = upMotorcycle.Model;
                tyre.TyreWidth = upMotorcycle.TyreWidth;
                tyre.HeightAspect = upMotorcycle.HeightAspect;
                tyre.RimSize = upMotorcycle.RimSize;
                //motorcycle.RearTyre = upMotorcycle.RearTyre;
                //tyre.Motorcycles = upMotorcycle.Motorcycles;

                _context.SaveChanges();
                return Created("", tyre);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteTyre(int id)
        {
            Tyre tyre = _context.Tyres.Find(id);
            if (tyre == null)
            {
                return NotFound();
            }
            else
            {
                _context.Tyres.Remove(tyre);

                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
