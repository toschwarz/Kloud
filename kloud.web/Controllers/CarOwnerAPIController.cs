using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kloud.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LinqGrouping.Models;
using kloud.web.Interfaces;

namespace kloud.web.Controllers
{
    [Produces("application/json")]
    [Route("api/CarOwnerAPI")]
    public class CarOwnerAPIController : Controller
    {
        /// <summary>
        /// Service for the API call
        /// </summary>
        private readonly ICarOwnerService _carownerService;

        /// <summary>
        /// Constructor for the CarOwnerAPI endpoint
        /// </summary>
        /// <param name="carownerService">Interface of the service for the API Call</param>
        public CarOwnerAPIController(ICarOwnerService carownerService)
        {
            _carownerService = carownerService;
        }

        // GET: api/CarOwnerAPI
        [HttpGet]
        public async Task<IActionResult> CarOwnerAPI()
        {
            // Retrieve the car owner list from the API
            string output = await _carownerService.CallAPI();

            // Deserialise the Json owner data from string and cast into an IEnumerable list of Owner.
            var carowners = JsonConvert.DeserializeObject<IEnumerable<Owner>>(output);

            // Let's group the results by brand of car as the BrandOwners model
            // Owner should be distinct since an owner can have multiple colours of a particular brand
            // Ordered by Brand
            var results = from o in carowners
                          from p in o.Cars
                          group o by p.Brand into g
                          orderby g.Key
                          select new BrandOwners { Brand = g.Key, Owners = g.Distinct() };

            return Ok(results);
        }
    }
}