using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kloud.web.Models
{
    public class Owner
    {
        /// <summary>
        /// Name of the Owner
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Cars owned by the Owner (as Array)
        /// </summary>
        public IEnumerable<Car> Cars
        {
            get; set;
        }
    }
}
