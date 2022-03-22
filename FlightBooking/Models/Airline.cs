using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class Airline
    {
        public Guid AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int BusinessSeat { get; set; }
        public int NonBusinessSeat { get; set; }

        public ICollection<Booking> Booking { get; set; }
        //public ICollection<Inventory> Inventory { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
    }
}
