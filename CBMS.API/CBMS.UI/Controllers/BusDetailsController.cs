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
    public class BusDetailsController : Controller
    {
       

        private IConfiguration _configuration;
        public BusDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> BusDetails()
        {
            IEnumerable<BusDetails> busDetails = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "BusDetails/GetBusDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        busDetails = JsonConvert.DeserializeObject<IEnumerable<BusDetails>>(result);
                    }
                }
            }
            return View(busDetails);
        }
        public IActionResult BusDetailsEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BusDetailsEntry(BusDetails busDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(busDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "BusDetails/AddBusDetails";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "BusDetails details saved successfully!";
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
