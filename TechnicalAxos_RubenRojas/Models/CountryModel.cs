using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAxos_RubenRojas.Models
{
    public class CountryModel
    {
        public CountryNameModel Name { get; set; }
        public string Flag { get; set; }
        public List<string> Capital { get; set; }
    }

    public class CountryNameModel
    {
        public string Common { get; set; }

        public string Official { get; set; }
    }

}
