using CBMS.DAL.Repository;
using CBMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBMS.BAL.Service
{
    public class TripService
    {
        ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public void AddTripDetails(Trip tripdetails)
        {
            _tripRepository.AddTripDetails(tripdetails);
        }
        public void DeleteTripDetails(int tripNo)
        {
            _tripRepository.DeleteTripDetails(tripNo);
        }
        public void UpdateTripDetails(Trip tripdetails)
        {
            _tripRepository.UpdateTripDetails(tripdetails);
        }
        public void GetTripNo(int tripNo)
        {
            _tripRepository.GetTripNo(tripNo);
        }
        public IEnumerable<Trip> GetTripDetails()
        {
            return _tripRepository.GetTripDetails().ToList();
        }
    }


}