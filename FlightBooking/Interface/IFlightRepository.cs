using FlightBooking.Models;
using FlightBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Interface
{
    public interface IFlightRepository
    {
        List<Inventory> SearchFlight(SearchViewModel model);
        List<Booking> BookFlight(BookingViewModel model);
        Booking SearchBookedFlight(string PNR);
        Booking CancelBooking(string PNR);
        List<Booking> BookingHistory(string EmailId);
        List<Booking> BookingHistory();
    }
}
