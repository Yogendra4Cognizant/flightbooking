using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public int Name { get; set; }
        public Int16 Gender { get; set; }
        public int Age { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
