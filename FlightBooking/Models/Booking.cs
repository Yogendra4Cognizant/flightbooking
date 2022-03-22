using System;
using System.Collections.Generic;


namespace FlightBooking.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Discount { get; set; }        
        public int NumberOfSeats { get; set; }
        public Int16 Meal { get; set; }
        public string PNR { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        //public Guid AirlineId { get; set; }
        //public Airline Airline { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public ICollection<Passenger> Passenger { get; set; }
        public bool IsActive { get; set; }

    }
}