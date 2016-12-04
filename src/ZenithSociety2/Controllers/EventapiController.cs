using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety2.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety2.Controllers
{

    [Route("api/[controller]")]
    public class EventapiController : Controller
    {
        private ZenithContext _context { get; set; }

        
        public EventapiController(ZenithContext context)
        {
            _context = context;
        }

        // GET: api/student
        //[Authorize]
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Event.ToList();
        }

        // GET api/studentapi/5
        [Authorize]
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _context.Event.FirstOrDefault(s => s.EventId == id);
        }

        // POST api/studentapi
        [Authorize]
        [HttpPost]
        public void Post([FromBody]Event e)
        {
            _context.Event.Add(e);
            _context.SaveChanges();
        }

        // PUT api/studentapi/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event e)
        {
            _context.Event.Update(e);
            _context.SaveChanges();
        }

        // DELETE api/studentapi/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Event = _context.Event.FirstOrDefault(t => t.EventId == id);
            if (Event != null)
            {
                _context.Event.Remove(Event);
                _context.SaveChanges();
            }
        }
    }
}
