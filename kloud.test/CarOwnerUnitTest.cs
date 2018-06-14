using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Json;
using System.Collections.Generic;
using kloud.web.Services;
using kloud.web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using kloud.web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace kloud.test
{
    public class CarOwnerUnitTest
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static AppSettings GetApplicationConfiguration(string outputPath)
        {
            var configuration = new AppSettings();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("ApplicationSettings")
                .Bind(configuration);

            return configuration;
        }

        private AppSettings configuration = GetApplicationConfiguration(AppContext.BaseDirectory);

        [Fact]
        public async Task TestOwnersAPI()
        {
            //Arrange
            var service = new CarOwnerService(configuration);

            //Act
            var result = await service.CallAPI();

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<string>();
        }

        [Fact]
        public async Task JSONTesting()
        {
            //Arrange
            var service = new CarOwnerService(configuration);

            //Act
            var result = await service.CallAPI();

            // Deserialise the Json owner data from string and cast into an IEnumerable list of Owner.
            Action act = () => { JsonConvert.DeserializeObject<IEnumerable<Owner>>(result); };

            //Assert
            act.Should().NotThrow<Exception>();

            var owners = JsonConvert.DeserializeObject<IEnumerable<Owner>>(result);
            owners.Should().HaveCount(10);  // Should have 10 items from the original API
        }

        [Fact]
        public async Task RepeaterTest()
        {
            //Arrange
            MockCarOwnerService mockservice = new MockCarOwnerService(configuration);
            var controller = new RepeaterAPIController(mockservice);

            //Act
            var output = await controller.RepeaterAPI();

            //Assert
            var result = output.Should().BeOfType<OkObjectResult>().Subject;
            var resultString = result.Value.Should().BeOfType<String>().Subject;
            var owners = JsonConvert.DeserializeObject<IEnumerable<Owner>>(resultString);

            owners.Should().HaveCount(2);  // Should have 2 items from the mocked API
        }

        [Fact]
        public async Task CarOwnerGroupTest()
        {
            //Arrange
            MockCarOwnerService mockservice = new MockCarOwnerService(configuration);
            var controller = new CarOwnerAPIController(mockservice);
            // Setup a mock filled Owner model
            var checkBrand = new BrandOwners
                {
                    Brand = @"Hyundai",
                    Owners = new List<Owner>
                    {
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
                    }
                };

            //Act
            var output = await controller.CarOwnerAPI();

            //Assert
            var result = output.Should().BeOfType<OkObjectResult>().Subject;

            var resultString = JsonConvert.SerializeObject(result.Value);

            // Deserialise the Json owner data from string and cast into an IEnumerable list of Owner.
            Action act = () => { JsonConvert.DeserializeObject<IEnumerable<BrandOwners>>(resultString); };
            act.Should().NotThrow<Exception>();

            var resultBrandowners = JsonConvert.DeserializeObject<IEnumerable<BrandOwners>>(resultString);

            resultBrandowners.Should().HaveCount(3);  // Should have 2 items from the mocked API
            resultBrandowners.First().Should().BeEquivalentTo(checkBrand);  // The first item should be Hyundai
        }
    }
}
