using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kloud.web.Models;
using kloud.web.Interfaces;

namespace kloud.web.Controllers
{
    [Route("api/RepeaterAPI")]
    public class RepeaterAPIController : Controller
    {
        /// <summary>
        /// Service for the API call
        /// </summary>
        private readonly ICarOwnerService _carownerService;

        /// <summary>
        /// Constructor for the RepeaterAPI endpoint
        /// </summary>
        /// <param name="carownerService">Interface of the service for the API Call</param>
        public RepeaterAPIController(ICarOwnerService carownerService)
        {
            _carownerService = carownerService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> RepeaterAPI()
        {
            string output = await _carownerService.CallAPI();
            return Ok(output);
        }

    }
}
