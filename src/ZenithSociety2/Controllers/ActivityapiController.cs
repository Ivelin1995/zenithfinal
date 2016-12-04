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
    public class ActivityapiController : Controller
    {
        private ZenithContext _context { get; set; }

        public ActivityapiController(ZenithContext context)
        {
            _context = context;
        }

        // GET: api/student
        //[Authorize]
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activity.ToList();
        }

        // GET api/studentapi/5
        [Authorize]
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activity.FirstOrDefault(s => s.ActivityId == id);
        }

        // POST api/studentapi
        [Authorize]
        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            _context.Activity.Add(activity);
            _context.SaveChanges();
        }

        // PUT api/studentapi/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Activity activity)
        {
            _context.Activity.Update(activity);
            _context.SaveChanges();
        }

        // DELETE api/studentapi/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activity = _context.Activity.FirstOrDefault(t => t.ActivityId == id);
            if (activity != null)
            {
                _context.Activity.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
