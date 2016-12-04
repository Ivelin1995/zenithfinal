using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety2.Models;
using Microsoft.EntityFrameworkCore;

namespace ZenithSociety2.Controllers
{
    public class HomeController : Controller
    {

        private ZenithContext db = new ZenithContext();
        public ActionResult Index()
        {


            Dictionary<String, List<Event>> Week = new Dictionary<String, List<Event>>();

            DateTime today = DateTime.Now;
            int delta = DayOfWeek.Monday - today.DayOfWeek;
            if (delta > 0)
                delta -= 7;
            DateTime monday = today.AddDays(delta);
            ViewBag.monday = monday.ToString();
            DateTime sunday = monday.AddDays(7);

            var @event = db.Event.Where(e => e.FromDate >= monday && e.FromDate < sunday).Include(that => that.Activity);

            foreach (var index in @event.OrderBy(name => name.FromDate).ToList())
            {
                if (index.IsActive)
                {
                    if (Week.ContainsKey(index.FromDate.ToString()))
                    {

                        Week[index.FromDate.ToString()].Add(index);
                    }
                    else
                    {
                        Week[index.FromDate.ToString()] = new List<Event> { index };
                    }
                }
            }

            ViewBag.Week = Week.ToList();

            return View();
        }
    }
}
