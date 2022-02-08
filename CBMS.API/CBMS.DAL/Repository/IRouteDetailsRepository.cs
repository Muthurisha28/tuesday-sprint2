using CBMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBMS.DAL.Repository
{
   public  interface IRouteDetailsRepository
    {
        public void AddRouteDetails(RouteDetails routedetails);
        public void UpdateRouteDetails(RouteDetails routedetails);
        public void DeleteRouteDetails(int routeNo);
        public RouteDetails GetRouteNo(int routeNo);
        IEnumerable<RouteDetails> GetRouteDetails();
    }
}
