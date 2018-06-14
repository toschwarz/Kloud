using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kloud.web.Models
{
    public class AppSettings
    {
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
        public string APIurl { get; set; }
        public Contact ContactInfo { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
