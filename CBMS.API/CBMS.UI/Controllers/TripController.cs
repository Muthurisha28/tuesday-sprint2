using CBMS.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CBMS.UI.Controllers
{
    public class TripController : Controller
    {
        private IConfiguration _configuration;
        public TripController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Trip()
        {
            IEnumerable<Trip> tripDetails = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Trip/GetTripDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        tripDetails = JsonConvert.DeserializeObject<IEnumerable<Trip>>(result);
                    }
                }
            }
            return View(tripDetails);
        }
        public IActionResult TripEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TripEntry(Trip tripDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(tripDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Trip/AddTripDetails";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Trip details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}
