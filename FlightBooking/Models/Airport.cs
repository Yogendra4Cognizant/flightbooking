using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class Airport
    {
        public Guid AirportId { get; set; }
        public string AirportName { get; set; }
        //public ICollection<Inventory> Source { get; set; }
        //public ICollection<Inventory> Destination { get; set; }
    }
}
