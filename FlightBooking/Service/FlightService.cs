using FlightBooking.Enums;
using FlightBooking.Models;
using FlightBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Service
{
    public class FlightService : IFlightRepository
    {
        private FlightDbContext _context;
        public FlightService(FlightDbContext _context)
        {
            this._context = _context;
        }
        public List<Inventory> SearchFlight(SearchViewModel model)
        {
            var Inventory = _context.Inventories.Where(x => x.SourceId == model.SourceId && x.DestinationId == model.DestinationId && x.StartDate.Date == model.DepartureDate.Date).ToList();

            if (model.TripType == EnumTripType.Round.GetHashCode())
            {
                Inventory.AddRange(_context.Inventories.Where(x => x.SourceId == model.DestinationId && x.DestinationId == model.SourceId && x.StartDate.Date == model.ReturnDate.GetValueOrDefault().Date).ToList());
            }
            return Inventory;
        }
        public List<BookingViewModel> BookFlight(List<BookingViewModel> Bookingmodel)
        {
            foreach (var model in Bookingmodel)
            {
                var booking = new Booking();
                booking.PNR = "PNR" + Guid.NewGuid().ToString();
                booking.Name = model.Name;
                booking.EmailId = model.Email;
                booking.Meal = model.Meal;
                booking.NumberOfSeats = model.NoOfSeats;
                booking.CreatedDate = DateTime.Now;
                booking.UpdatedDate = DateTime.Now;
                booking.InventoryId = model.InventoryId;
                booking.AirlineId = model.AirlineId;
                booking.IsActive = true;
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                foreach (var item in model.passenger)
                {
                    _context.Passengers.Add(new Passenger { Name = item.Name, Gender = item.Gender, Age = item.Age, BookingId = booking.BookingId });
                }
                _context.SaveChanges();
            }
            return Bookingmodel;
        }
        public List<Booking> BookingHistory(string EmailId)
        {
            return _context.Bookings.Where(x => x.EmailId == EmailId && x.IsActive == true).ToList();
        }
        public Booking CancelBooking(string PNR)
        {
            var res = _context.Bookings.Where(x => x.PNR == PNR && x.IsActive == true).FirstOrDefault();
            res.IsActive = false;
            _context.SaveChanges();
            return res;
        }

        public Booking SearchBookedFlight(string PNR)
        {
            return _context.Bookings.Where(x => x.PNR == PNR && x.IsActive == true).FirstOrDefault();
        }
    }
}
