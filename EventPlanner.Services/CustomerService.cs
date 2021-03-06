using EventPlanner.Data;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var id = ctx.Events.SingleOrDefault(e => e.EventId == model.EventId);
                if (id != null)
                {
                    var entity
                        = new Customer()
                        {
                            OwnerId = _userId,
                            CustomerFName = model.CustomerFName,
                            CustomerLName = model.CustomerLName,
                            CustomerMInitial = model.CustomerMInitial,
                            Address = model.Address,
                            City = model.City,
                            State = model.State,
                            CreatedUtc = DateTimeOffset.Now,

                        };
                    entity.Events.Add(id);

                    ctx.Customers.Add(entity);
                   
                    return ctx.SaveChanges() == 2;
                }
                return false;
            }
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query
                    = ctx
                    .Customers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            CustomerFName = e.CustomerFName,
                            CustomerLName = e.CustomerLName,
                            CustomerMInitial = e.CustomerMInitial,
                            Address = e.Address,
                            City = e.City,
                            State = e.State,
                            CreatedUtc = e.CreatedUtc

                        });
                return query.ToArray();
            }
        }
        public CustomerDetails GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Customers
                    .Single(e => e.CustomerId == id && e.OwnerId == _userId);

                var Details = new CustomerDetails
                {
                    CustomerId = entity.CustomerId,
                    CustomerFName = entity.CustomerFName,
                    CustomerLName = entity.CustomerLName,
                    CustomerMInitial = entity.CustomerMInitial,
                    City = entity.City,
                    Address = entity.Address,
                    State = entity.State,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                 
                
                Events = new List<EventListItem>()
                };
            foreach (var item in entity.Events)
            {
                var eventList = new EventListItem()
                {
                    EventId = item.EventId,
                    EventTitle = item.EventTitle
                };
                Details.Events.Add(eventList);

            }
            return Details;
            }
        }
        public bool EditCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Customers
                    .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.CustomerFName = model.CustomerFName;
                entity.CustomerLName = model.CustomerLName;
                entity.CustomerMInitial = model.CustomerMInitial;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Customers
                    .Single(e => e.CustomerId == id && e.OwnerId == _userId);
                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
