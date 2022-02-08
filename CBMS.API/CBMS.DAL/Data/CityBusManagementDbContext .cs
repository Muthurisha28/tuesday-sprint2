using CBMS.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBMS.DAL.Data
{
    public class CityBusManagementDbContext : DbContext
    {
        public CityBusManagementDbContext(DbContextOptions<CityBusManagementDbContext> options) : base(options)
        {
        }
        public DbSet<RouteDetails> routedetails { get; set; }

        public DbSet<BusDetails> busdetails { get; set; }
        public DbSet<BusStop> busstop { get; set; }
        public DbSet<Trip> trip { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<AdminInfo> adminInfo { get; set; }



    }
}