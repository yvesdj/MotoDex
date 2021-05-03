using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EnginesController : ControllerBase
    {
        private readonly MotorcyclesContext _context;

        public EnginesController(MotorcyclesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateEngine([FromBody] Engine newEngine)
        {
            _context.Engines.Add(newEngine);
            _context.SaveChanges();

            return Created("", newEngine);
        }


        [HttpGet]
        public IEnumerable<Engine> GetAllEngines()
        {
            return _context.Engines.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetEngine(int id)
        {
            Engine engine = _context.Engines
                .SingleOrDefault(engine => engine.Id == id);

            if (engine == null)
                return NotFound();

            return Ok(engine);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateEngine(int id, [FromBody] Engine upEngine)
        {
            Engine engine = _context.Engines.Find(id);
            if (engine == null)
            {
                return NotFound();
            }
            else
            {
                engine.EngineType = upEngine.EngineType;
                engine.EngineConfiguration = upEngine.EngineConfiguration;
                engine.Capacity = upEngine.Capacity;
                engine.MaxPower = upEngine.MaxPower;
                engine.MaxTorque = upEngine.MaxTorque;
                //motorcycle.RearTyre = upMotorcycle.RearTyre;
                engine.Cooling = upEngine.Cooling;
                engine.InductionType = upEngine.InductionType;
                engine.SparkPlug = upEngine.SparkPlug;

                _context.SaveChanges();
                return Created("", engine);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteEngine(int id)
        {
            Engine engine = _context.Engines.Find(id);
            if (engine == null)
            {
                return NotFound();
            }
            else
            {
                _context.Engines.Remove(engine);

                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
