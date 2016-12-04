using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety2.Models;
using ZenithSociety2.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety2.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class AccountapiController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public AccountapiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/student
        [Authorize]
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/studentapi/5
        [Authorize]
        [HttpGet("{id}")]
        public ApplicationUser Get(String id)
        {
            return _context.Users.FirstOrDefault(s => s.Id == id);
        }

        // POST api/studentapi
        [Authorize]
        [HttpPost]
        public void Post([FromBody]ApplicationUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // PUT api/studentapi/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ApplicationUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        // DELETE api/studentapi/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }

}
