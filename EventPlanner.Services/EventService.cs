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
                            CreatedUtc = e.CreatedUtc
                        });
                return Query.ToArray();
            }

        }
        public EventDetails GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Events
                    .Single(e => e.EventId == id && e.OwnerId == _userId);
                var details = new EventDetails()
                {
                    EventId = entity.EventId,
                    EventTitle = entity.EventTitle,
                    Price = entity.Price,
                    Address = entity.Address,
                    City = entity.City,
                    State = entity.State,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                    CustomerId = entity.Customers.Select(e => e.CustomerId).ToList(),
                    CustomerFName = entity.Customers.Select(e => e.CustomerFName).ToList(),
                    CustomerLName = entity.Customers.Select(e => e.CustomerLName).ToList()
                };

                //Customer = new List<CustomerListItem>()
                return details;
            };
            //foreach (var item in entity.Customers)
            //{
            //    var CustList = new CustomerListItem()
            //    {
            //        CustomerId = item.Customer.CustomerId,
            //        CustomerFName = item.Customer.CustomerFName,
            //        CustomerLName = item.Customer.CustomerLName,
            //        CustomerMInitial = item.Customer.CustomerMInitial
            //    };
            //    details.Customer.Add(CustList);
        }



        public bool EditEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                     = ctx
                     .Events
                     .Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.EventId = model.EventId;
                entity.EventTitle = model.EventTitle;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Price = model.Price;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Events
                    .Single(e => e.EventId == id && e.OwnerId == _userId);
                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


