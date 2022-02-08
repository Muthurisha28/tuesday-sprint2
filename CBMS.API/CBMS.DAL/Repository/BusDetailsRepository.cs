using CBMS.DAL.Data;
using CBMS.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBMS.DAL.Repository
{
    public class BusDetailsRepository : IBusDetailsRepository
    {
        CityBusManagementDbContext _busDetailsDbContext;


        public BusDetailsRepository(CityBusManagementDbContext busDetailsDbContext)
        {
            _busDetailsDbContext = busDetailsDbContext;
        }

        public void AddBusDetails(BusDetails busdetails)
        {
            _busDetailsDbContext.busdetails.Add(busdetails);
            _busDetailsDbContext.SaveChanges();

        }
        public void DeleteBusDetails(int busNo)
        {
            var busdetails = _busDetailsDbContext.busdetails.Find(busNo);
            _busDetailsDbContext.busdetails.Remove(busdetails);
            _busDetailsDbContext.SaveChanges();
        }

        public IEnumerable<BusDetails> GetBusDetails()
        {
            return _busDetailsDbContext.busdetails.ToList();
        }

        public BusDetails GetBusNo(int busNo)
        {
            return _busDetailsDbContext.busdetails.Find(busNo);
        }

        public void UpdateBusDetails(BusDetails busdetails)
        {
            _busDetailsDbContext.Entry(busdetails).State = EntityState.Modified;
            _busDetailsDbContext.SaveChanges();
        }

    }
}
