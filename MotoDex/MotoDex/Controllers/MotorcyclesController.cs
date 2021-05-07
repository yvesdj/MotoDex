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
                    .ThenInclude(mft => mft.FrontTyre)
                .Include(moto => moto.MotorcycleRearTyres)
                    .ThenInclude(mrt => mrt.RearTyre)
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
            Motorcycle motorcycle = _context.Motorcycles
                //.Include(mft => mft.MotorcycleFrontTyres)
                //.Include(mrt => mrt.MotorcycleRearTyres)
                .SingleOrDefault(moto => moto.Id == id);



            if (motorcycle == null)
            {
                return NotFound();
            }
            else
            {
                motorcycle.MakeId = upMotorcycle.MakeId;
                motorcycle.Model = upMotorcycle.Model;
                motorcycle.EngineId = upMotorcycle.EngineId;
                motorcycle.FinalDrive = upMotorcycle.FinalDrive;

                //motorcycle.MotorcycleFrontTyres.Add(new MotorcycleFrontTyres
                //{
                //    FrontTyreId = upMotorcycle.MotorcycleFrontTyres.FrontTyreId
                //});
                foreach (MotorcycleFrontTyres mft in upMotorcycle.MotorcycleFrontTyres)
                {
                    motorcycle.MotorcycleFrontTyres.Add(new MotorcycleFrontTyres
                    {
                        FrontTyreId = mft.FrontTyreId,
                        MotorcycleId = motorcycle.Id
                    });
                }

                foreach (MotorcycleRearTyres mft in upMotorcycle.MotorcycleRearTyres)
                {
                    motorcycle.MotorcycleRearTyres.Add(new MotorcycleRearTyres
                    {
                        RearTyreId = mft.RearTyreId,
                        MotorcycleId = motorcycle.Id
                    });
                }

                motorcycle.FrontBreakPadsId = upMotorcycle.FrontBreakPadsId;
                motorcycle.RearBreakPadsId = upMotorcycle.RearBreakPadsId;

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
