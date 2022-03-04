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
        List<BookingViewModel> BookFlight(List<BookingViewModel> model);
        Booking SearchBookedFlight(string PNR);
        Booking CancelBooking(string PNR);
        List<Booking> BookingHistory(string EmailId);
    }
}
