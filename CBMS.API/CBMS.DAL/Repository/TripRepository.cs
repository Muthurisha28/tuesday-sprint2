using CBMS.DAL.Data;
using CBMS.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBMS.DAL.Repository
{
    public class TripRepository : ITripRepository
    {
        CityBusManagementDbContext _tripDbContext;
        public TripRepository(CityBusManagementDbContext tripDbContext)
        {
            _tripDbContext = tripDbContext;
        }

        public void AddTripDetails(Trip tripdetails)
        {
            _tripDbContext.trip.Add(tripdetails);
            _tripDbContext.SaveChanges();
        }

        public void DeleteTripDetails(int tripNo)
        {
            var tripdetails = _tripDbContext.trip.Find(tripNo);
            _tripDbContext.trip.Remove(tripdetails);
            _tripDbContext.SaveChanges();
        }

        public IEnumerable<Trip> GetTripDetails()
        {
            return _tripDbContext.trip.ToList();
        }

        public Trip GetTripNo(int tripNo)
        {
            return _tripDbContext.trip.Find(tripNo);
        }

        public void UpdateTripDetails(Trip tripdetails)
        {

            _tripDbContext.Entry(tripdetails).State = EntityState.Modified;
            _tripDbContext.SaveChanges();
        }
    }
}