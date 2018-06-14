using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using kloud.web.Interfaces;
using kloud.web.Models;
using Newtonsoft.Json;

namespace kloud.test
{
    public class MockCarOwnerService : ICarOwnerService
    {
        /// <summary>
        /// Application Settings
        /// </summary>
        public readonly AppSettings _appSettings;

        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Cars service constructor
        /// </summary>
        public MockCarOwnerService(AppSettings appsettings)
        {
            _appSettings = appsettings;
        }

        /// <summary>
        /// Retrieves the Json (as string) from the API via HttpClient
        /// </summary>
        /// <returns>Output from the API as string</returns>
        public async Task<string> CallAPI()
        {
            // Setup a mock filled Owner model
            var owners = new List<Owner>
            {
                new Owner
                {
                    Name = @"John",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Mazda",
                           Colour = @"Grey"
                       }
                    }
                },
                new Owner
                {
                    Name = @"Betty",
                    Cars = new List<Car>
                    {
                       new Car
                       {
                           Brand = @"Toyota",
                           Colour = @"Blue"
                       },
                       new Car
                       {
                           Brand = @"Hyundai",
                           Colour = @"Blue"
                       }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(owners);
            return json;
        }
    }
}
