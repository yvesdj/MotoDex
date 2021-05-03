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
    public class BreakPadsController : ControllerBase
    {
        private readonly MotorcyclesContext _context;

        public BreakPadsController(MotorcyclesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateBreakPad([FromBody] BreakPad newBreakPad)
        {
            _context.BreakPads.Add(newBreakPad);
            _context.SaveChanges();

            return Created("", newBreakPad);
        }


        [HttpGet]
        public IEnumerable<BreakPad> GetAllBreakPads()
        {
            return _context.BreakPads.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBreakPad(int id)
        {
            BreakPad breakPad = _context.BreakPads
                .SingleOrDefault(breakPad => breakPad.Id == id);

            if (breakPad == null)
                return NotFound();

            return Ok(breakPad);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateBreakPad(int id, [FromBody] BreakPad upBreakPad)
        {
            BreakPad breakPad = _context.BreakPads.Find(id);
            if (breakPad == null)
            {
                return NotFound();
            }
            else
            {
                breakPad.PadType = upBreakPad.PadType;
                breakPad.Make = upBreakPad.Make;
                breakPad.Model = upBreakPad.Model;

                _context.SaveChanges();
                return Created("", breakPad);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteBreakPad(int id)
        {
            BreakPad breakPad = _context.BreakPads.Find(id);
            if (breakPad == null)
            {
                return NotFound();
            }
            else
            {
                _context.BreakPads.Remove(breakPad);

                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
