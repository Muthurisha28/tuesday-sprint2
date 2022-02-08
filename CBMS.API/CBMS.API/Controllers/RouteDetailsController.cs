using CBMS.BAL.Service;
using CBMS.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBMS_API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RouteDetailsController : ControllerBase
    {
        private RouteDetailsService _routeDetailsService;
        public RouteDetailsController(RouteDetailsService routeDetailsService)
        {
            _routeDetailsService = routeDetailsService;
        }

        [HttpPost("AddRouteDetails")]
        public IActionResult AddRouteDetails([FromBody] RouteDetails routedetails)
        {
            _routeDetailsService.AddRouteDetails(routedetails);

            return Ok("Route Details Added Successfully!!!");
        }

        [HttpGet("GetRouteDetails")]
        public IEnumerable<RouteDetails> GetRouteDetails()
        {
            return _routeDetailsService.GetRouteDetails();
        }

        [HttpDelete("DeleteRouteDetails")]
        public IActionResult DeleteRouteDetails(int routeNo)
        {
            _routeDetailsService.DeleteRouteDetails(routeNo);
            return Ok("Route Details Deleted Successfully!!!");
        }

        [HttpPut("UpdateRouteDetails")]
        public IActionResult UpdateRouteDetails([FromBody] RouteDetails routeDetails)
        {
            _routeDetailsService.UpdateRouteDetails(routeDetails);
            return Ok("Route Details Updated Successfully!!!");
        }

    }
}