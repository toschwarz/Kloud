using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kloud.web.Models
{
    /// <summary>
    /// Model for the required output of the project.
    /// That is: Brand of car with its associated list of Owners.
    /// </summary>
    public class BrandOwners
    {
        /// <summary>
        /// Brand of the Car
        /// </summary>
        public string Brand
        {
            get; set;
        }

        /// <summary>
        /// Owners of the brand (as Array)
        /// </summary>
        public IEnumerable<Owner> Owners
        {
            get; set;
        }
    }
}
