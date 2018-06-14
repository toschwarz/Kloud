using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kloud.web.Models;
using Newtonsoft.Json;

namespace kloud.web.Controllers
{
    [Route("api/RepeaterAPI")]
    public class RepeaterAPIController : Controller
    {
        ///// <summary>
        ///// Service for the API call
        ///// </summary>
        //private readonly ICarOwnerService _carownerService;

        ///// <summary>
        ///// Constructor for the RepeaterAPI endpoint
        ///// </summary>
        ///// <param name="carownerService">Interface of the service for the API Call</param>
        //public RepeaterAPIController(ICarOwnerService carownerService)
        //{
        //    _carownerService = carownerService;
        //}

        // GET api/RepeaterAPI
        [HttpGet]
        public async Task<IActionResult> RepeaterAPI()
        {
            // Set up the owner object per the given API
            var owners = new List<Owner>
            {
                new Owner
                {
                    Name = @"Bradley",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"MG",
                           Colour = @"Blue"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Demetrios",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Toyota",
                           Colour = @"Green"
                       },
                       new Car
                       {
                           Brand = @"Holden",
                           Colour = @"Blue"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Brooke",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Holden"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Kristin",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Toyota",
                           Colour = @"Blue"
                       },
                       new Car
                       {
                           Brand = @"Mercedes",
                           Colour = @"Green"
                       },
                       new Car
                       {
                           Brand = @"Mercedes",
                           Colour = @"Yellow"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Andre",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"BMW",
                           Colour = @"Green"
                       },
                       new Car
                       {
                           Brand = @"Holden",
                           Colour = @"Black"
                       }
                    }
                },
                new Owner
                {
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Mercedes",
                           Colour = @"Blue"
                       }
                    }
                },
                new Owner
                {
                    Name = @"",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Mercedes",
                           Colour = @"Red"
                       },
                       new Car
                       {
                           Brand = @"Mercedes",
                           Colour = @"Blue"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Matilda",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Holden"
                       },
                       new Car
                       {
                           Brand = @"BMW",
                           Colour = @"Black"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Iva",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Toyota",
                           Colour = @"Purple"
                       }
                    }
                },
                new Owner
                {
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Toyota",
                           Colour = @"Blue"
                       },
                       new Car
                       {
                           Brand = @"Mercedes",
                           Colour = @"Blue"
                       }
                    }
                }
            };

            // Serialize the owner object to Json string
            var task = await Task.Run<String>(() =>
            {
                var json = JsonConvert.SerializeObject(owners);
                return json;
            });

            return Ok(task);

        }

    }
}
