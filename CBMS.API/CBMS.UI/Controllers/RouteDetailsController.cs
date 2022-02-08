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
    public class RouteDetailsController : Controller
    {
        private IConfiguration _configuration;
        public RouteDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> RouteDetails()
        {
            IEnumerable<RouteDetails> routeDetails = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/GetRouteDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        routeDetails = JsonConvert.DeserializeObject<IEnumerable<RouteDetails>>(result);
                    }
                }
            }
            return View(routeDetails);
        }
        public IActionResult RouteDetailsEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RouteDetailsEntry(RouteDetails routeDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(routeDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/AddRouteDetails";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "RouteDetails details saved successfully!";
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
        public async Task<IActionResult> GetRouteDetails()
        {
            IEnumerable<RouteDetails> routeResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/GetRouteDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        routeResult = JsonConvert.DeserializeObject<IEnumerable<RouteDetails>>(result);
                    }
                }
            }
            return View(routeResult);
        }
        public async Task<IActionResult> UpdateRouteDetails(int routeId)
        {
            RouteDetails routeResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/UpdateRouteDetails?routeId" + routeId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        routeResult = JsonConvert.DeserializeObject<RouteDetails>(result);
                    }
                }
            }
            return View(routeResult);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRouteDetails(RouteDetails routeDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(routeDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/UpdateEmployee";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Route details Updated successfully!";
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

        public async Task<IActionResult> DeleteRouteDetails(int routeId)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/DeleteRouteDetails?routeId" + routeId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Route details Deleted successfully!";
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