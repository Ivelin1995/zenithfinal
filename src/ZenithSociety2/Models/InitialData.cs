using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSociety2.Models
{
    public class InitialData
    {
        public static void Initialize(ZenithContext db)
        {
            /*
            db.Activity.Add(new Activity
            {
                //ActivityId = 1,
                ActivityDescription = "Young ladies cooking lessons",
                CreationDate = new DateTime(2015, 12, 30, 23, 59, 59)
            });
            db.Activity.Add(new Activity
            {
                //ActivityId = 2,
                ActivityDescription = "Youth choir practice",
                CreationDate = new DateTime(2015, 12, 30, 23, 59, 59)
            });
            db.Activity.Add(new Activity
            {
                //ActivityId = 3,
                ActivityDescription = "Bingo Tournament",
                CreationDate = new DateTime(2015, 12, 30, 23, 59, 59)
            });
            db.SaveChanges();
            
            */
            
            
            db.Event.Add(new Event
            {
               // EventId = 1,
                FromDate = new DateTime(2016, 11, 5, 19, 0, 0),
                ToDate = new DateTime(2016, 11, 5, 20, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 11, 4, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            db.Event.Add(new Event
            {
                //EventId = 2,
                FromDate = new DateTime(2016, 11, 6, 10, 30, 0),
                ToDate = new DateTime(2016, 11, 6, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = false,
                CreationDate = new DateTime(2016, 11, 5, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 95)
            });
            db.Event.Add(new Event
            {
               // EventId = 3,
                FromDate = new DateTime(2016, 11, 7, 10, 30, 0),
                ToDate = new DateTime(2016, 11, 7, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 11, 6, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 96)
            });
            db.Event.Add(new Event
            {
               // EventId = 4,
                FromDate = new DateTime(2016, 11, 7, 10, 30, 0),
                ToDate = new DateTime(2016, 11, 7, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 11, 6, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            db.Event.Add(new Event
            {
               // EventId = 5,
                FromDate = new DateTime(2016, 10, 28, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 28, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 95)
            });
            db.Event.Add(new Event
            {
               // EventId = 6,
                FromDate = new DateTime(2016, 10, 25, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 25, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            db.Event.Add(new Event
            {
                //EventId = 7,
                FromDate = new DateTime(2016, 10, 26, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 26, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 95)
            });
            db.Event.Add(new Event
            {
                //EventId = 8,
                FromDate = new DateTime(2016, 10, 27, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 27, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 96)
            });
            db.Event.Add(new Event
            {
               // EventId = 9,
                FromDate = new DateTime(2016, 10, 27, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 27, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            db.Event.Add(new Event
            {
                //EventId = 10,
                FromDate = new DateTime(2016, 10, 28, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 28, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            db.Event.Add(new Event
            {
               // EventId = 11,
                FromDate = new DateTime(2016, 10, 29, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 29, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 95)
            });
            db.Event.Add(new Event
            {
                //EventId = 12,
                FromDate = new DateTime(2016, 10, 21, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 21, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId ==95)
            });
            db.Event.Add(new Event
            {
                //EventId = 13,
                FromDate = new DateTime(2016, 10, 21, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 21, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            db.Event.Add(new Event
            {
                //EventId = 14,
                FromDate = new DateTime(2016, 10, 22, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 22, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 95)
            });
            db.Event.Add(new Event
            {

                //EventId = 15,
                FromDate = new DateTime(2016, 10, 23, 10, 30, 0),
                ToDate = new DateTime(2016, 10, 23, 12, 0, 0),
                CreatedBy = "Ivelin",
                IsActive = true,
                CreationDate = new DateTime(2016, 10, 20, 12, 0, 0),
                Activity = db.Activity.First(a => a.ActivityId == 94)
            });
            

            db.SaveChanges();
            
        }
    }
}
