using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AppRepository : IAppRepository
    {
        private ApplicationContext _context;

        public AppRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var rowsCount = await _context.SaveChangesAsync();
            return rowsCount > 0;
        }

        //public IEnumerable TripGet()
        //{
        //    return _context.Trips
        //        .Include(t => t.Stops)
        //        .ToList();
        //}
        //public void TripAdd(Trip trip)
        //{
        //    _context.Add(trip);
        //}

        //public async Task<IEnumerable<Stop>> StopsGetByTripNameAsync(string tripName)
        //{
        //    var trip = await _context.Trips
        //        .Include(t => t.Stops)
        //        .Where(t => t.Name == tripName)
        //        .FirstOrDefaultAsync();
        //    return trip.Stops;
        //}

        //public void StopAdd(string tripName, Stop stop)
        //{
        //    var trip = _context.Trips
        //        .Include(t => t.Stops)
        //        .Where(t => t.Name == tripName)
        //        .FirstOrDefault();

        //    trip.Stops.Add(stop);
        //    _context.Stops.Add(stop);
        //}

        public void UserAdd(User user)
        {
            _context.Users.Add(user);
        }
    }
}
