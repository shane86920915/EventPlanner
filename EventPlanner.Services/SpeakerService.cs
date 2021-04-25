using EventPlanner.Models;
using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class SpeakerService
    {
        private readonly Guid _userid;

        public SpeakerService(Guid UserId)
        {
            _userid = UserId;
        }

        public bool CreateSpeaker(SpeakerCreate model)
        {
            var entity
                = new Speaker()
                {
                    OwnerId = _userid,
                    SpeakerFName = model.SpeakerFName,
                    SpeakerLName = model.SpeakerLName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Speakers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpeakerListItem> GetSpeaker()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Query
                    = ctx
                    .Speakers
                    .Where(e => e.OwnerId == _userid)
                    .Select(
                        e =>
                        new SpeakerListItem()
                        {
                            SpeakerId = e.SpeakerId,
                            SpeakerFName = e.SpeakerFName,
                            SpeakerLName = e.SpeakerLName,
                            Address = e.Address,
                            City = e.City,
                            State = e.State,
                            CreatedUtc = DateTimeOffset.Now

                        });
                return Query.ToArray();
            }
        }

        public SpeakerDetails GetSpeakerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Speakers
                    .Single(e => e.SpeakerId == id && e.OwnerId == _userid);
                var details
                    = new SpeakerDetails()
                    {
                        SpeakerId = entity.SpeakerId,
                        SpeakerFName = entity.SpeakerFName,
                        SpeakerLName = entity.SpeakerLName,
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
                return details;
            }
        }
        public bool EditSpeaker(SpeakerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Speakers
                    .Single(e => e.SpeakerId == model.SpeakerId && e.OwnerId == _userid);

                entity.SpeakerId = model.SpeakerId;
                entity.SpeakerFName = model.SpeakerFName;
                entity.SpeakerLName = model.SpeakerLName;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSpeaker(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity
                    = ctx
                    .Speakers
                    .Single(e => e.SpeakerId == id && e.OwnerId == _userid);
                ctx.Speakers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}



