using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.ViewModels
{
    public class BookingViewModel
    {
        public Guid InventoryId { get; set; }
        public Guid AirlineId { get; set; }
        public Guid AirPortId { get; set; }
        public int MealPreference { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int NoOfSeats { get; set; }
        public Int16 Meal { get; set; }
        public List<PassengerViewModel> passenger { get; set; }
    }
}
