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
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private TripService _tripService;
        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost("AddTripDetails")]
        public IActionResult AddTripDetails([FromBody] Trip tripdetails)
        {
            _tripService.AddTripDetails(tripdetails);

            return Ok("Trip Details Added Successfully!!!");
        }

        [HttpGet("GetTripDetails")]
        public IEnumerable<Trip> GetTripDetails()
        {
            return _tripService.GetTripDetails();
        }

        [HttpDelete("DeleteTripDetails")]
        public IActionResult DeleteTripDetails(int tripNo)
        {
            _tripService.DeleteTripDetails(tripNo);
            return Ok("Trip Details Deleted Successfully!!!");
        }

        [HttpPut("UpdateTripDetails")]
        public IActionResult UpdateTripDetails([FromBody] Trip tripDetails)
        {
            _tripService.UpdateTripDetails(tripDetails);
            return Ok("Trip Details Updated Successfully!!!");
        }
    }
}
