using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace CBMS.Entity.Model
{
    public class BusStop
    {
        [Key]
        public int busStopNo { get; set; }
        public string stopName { get; set; }
        public int arrivalTime { get; set; }
        public int depatureTime { get; set; }
        public virtual ICollection<RouteDetails> routeDetails { get; set; }


    }
}