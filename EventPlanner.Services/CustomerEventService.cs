using EventPlanner.Data;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class CustomerEventService
    {
        private readonly Guid _userId;
        public CustomerEventService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomerEvent(CustomerEventCreate model)
        {
            var entity
                = new CustomerEvent()
                {
                    OwnerId = _userId,   
                    CustomerId = model.CustomerId,
                    EventId = model.EventId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerEvents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
