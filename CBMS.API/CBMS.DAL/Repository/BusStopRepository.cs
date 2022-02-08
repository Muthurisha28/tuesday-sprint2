using CBMS.DAL.Data;
using CBMS.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBMS.DAL.Repository
{
    public class BusStopRepository : IBusStopRepository
    {
        CityBusManagementDbContext _busStopDbContext;
        public BusStopRepository(CityBusManagementDbContext busStopDbContext)
        {
            _busStopDbContext = busStopDbContext;
        }
        public void AddBusStop(BusStop busstop)
        {
            _busStopDbContext.busstop.Add(busstop);
            _busStopDbContext.SaveChanges();
        }

        public void DeleteBusStop(int busno)
        {
            var routedetails = _busStopDbContext.busstop.Find(busno);
            _busStopDbContext.busstop.Remove(routedetails);
            _busStopDbContext.SaveChanges();
        }

        public BusStop GetBusNo(int busno)
        {
            return _busStopDbContext.busstop.Find(busno);
        }

        public IEnumerable<BusStop> GetBusStop()
        {
            return _busStopDbContext.busstop.ToList();
        }

        public void UpdateBusStop(BusStop busstop)
        {
            _busStopDbContext.Entry(busstop).State = EntityState.Modified;
            _busStopDbContext.SaveChanges();
        }
    }
}
