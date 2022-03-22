using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.ViewModels
{
    public class BookingViewModel
    {
        public Guid InvOnewayId { get; set; }
        public Guid InvReturnId { get; set; }
        public Guid AirlineId { get; set; }
        public Guid AirPortId { get; set; }
        public int MealPreference { get; set; }
        public string DiscountCode { get; set; }
        public bool DiscountApplied { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public int NoOfSeats { get; set; }
        public Int16 Meal { get; set; }
        public List<PassengerViewModel> passenger { get; set; }
    }
}
