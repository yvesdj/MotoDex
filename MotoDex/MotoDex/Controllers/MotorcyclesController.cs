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
        public IEnumerable<Motorcycle> GetAllMotorcycles(string model, string make, string sort, string dir)
        {
            IQueryable<Motorcycle> motos = _context.Motorcycles;

            if (!string.IsNullOrWhiteSpace(model))
            {
                motos = motos.Where(moto => moto.Model == model);
                //return motos;
            }
            if (!string.IsNullOrWhiteSpace(make))
            {
                motos = motos
                    .Where(moto => moto.Make.Name == make);
                //return motos;
            }
            //return _context.Motorcycles.ToList();
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "make":
                        if (dir == "asc")
                            motos = motos.OrderBy(moto => moto.Make.Name);
                        else if (dir == "desc")
                            motos = motos.OrderByDescending(moto => moto.Make.Name);
                        break;

                    case "model":
                        if (dir == "asc")
                            motos = motos.OrderBy(moto => moto.Model);
                        else if (dir == "desc")
                            motos = motos.OrderByDescending(moto => moto.Model);
                        break;

                    default:
                        break;
                }
            }

            return motos.ToList();
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


                // Check is not possible because motorcycle tyres arent queried
                // So motorcycle.MotorcycleFrontTyres == 0
                //foreach (MotorcycleFrontTyres upMft in upMotorcycle.MotorcycleFrontTyres)
                //{
                //    foreach (MotorcycleFrontTyres mft in motorcycle.MotorcycleFrontTyres)
                //    {
                //        if (upMft.FrontTyreId == mft.FrontTyreId)
                //        {
                //            continue;
                //        }
                //        else
                //        {
                //            motorcycle.MotorcycleFrontTyres.Add(new MotorcycleFrontTyres
                //            {
                //                FrontTyreId = upMft.FrontTyreId,
                //                MotorcycleId = motorcycle.Id
                //            });
                //        }
                //    }
                //}

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
