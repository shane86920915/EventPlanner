using EventPlanner.Models;
using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity
                = new Event()
                {
                    OwnerId = _userId,
                    EventTitle = model.EventTitle,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Price = model.Price,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Query
                    = ctx
                    .Events
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new EventListItem()
                        {
                            EventId = e.EventId,
                            EventTitle = e.EventTitle,
                            Address = e.Address,
                            City = e.City,
                            State = e.State,
                            CreatedUtc = DateTimeOffset.Now

                         
                        }) ;
                return Query.ToArray();
            }

        }
    }
}
