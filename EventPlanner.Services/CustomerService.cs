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
        public readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
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
                    CreatedUtc = DateTimeOffset.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
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

        //public CustomerDetails GetCustomerById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity
        //            = ctx
        //            .Customers
        //            .Single(e => e.CustomerId == id && _userId == e.OwnerId);

        //        return new CustomerDetails
        //        {
        //            CustomerId = entity.CustomerId,
        //            CustomerFName = entity.CustomerFName,
        //            CustomerLName = entity.CustomerLName,
        //            CustomerMInitial = entity.CustomerMInitial,
        //            City = entity.City,
        //            Address = entity.Address,
        //            State = entity.State,
        //            CreatedUtc = entity.CreatedUtc,
        //            ModifiedUtc = entity.ModifiedUtc,
        //            Event = new EventListItem() { EventId = entity.e}
        //        }

            
        
    }
}
