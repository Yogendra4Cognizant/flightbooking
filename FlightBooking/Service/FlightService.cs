using FlightBooking.Enums;
using FlightBooking.Interface;
using FlightBooking.Models;
using FlightBooking.ViewModels;
using Microsoft.EntityFrameworkCore;
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
            var Inventory = _context.Inventories.Include(c => c.Airline).Include(x => x.Destination).Include(x => x.Source).Where(x => x.SourceId == model.SourceId && x.DestinationId == model.DestinationId && x.StartDate.Date == model.DepartureDate.Date).ToList();
            Inventory.ForEach(x =>
            {
                x.TripType = 1;
                x.TotalHour = getDateDifference(x.EndDate, x.StartDate);
            });
            if (model.TripType == EnumTripType.Round.GetHashCode())
            {
                var res = _context.Inventories.Include(c => c.Airline).Include(x => x.Destination).Include(x => x.Source).Where(x => x.SourceId == model.DestinationId && x.DestinationId == model.SourceId && x.StartDate.Date == model.ReturnDate.GetValueOrDefault().Date).ToList();
                res.ForEach(x =>
                {
                    x.TripType = 2;
                    x.TotalHour = getDateDifference(x.EndDate, x.StartDate);
                });
                Inventory.AddRange(res);
            }
            return Inventory;
        }
        string getDateDifference(DateTime endDate, DateTime startDate)
        {
            TimeSpan diffDate = endDate.Subtract(startDate);
            return diffDate.Hours + "Hr " + diffDate.Minutes + "min";
        }
        public List<Booking> BookFlight(BookingViewModel model)
        {
            List<Booking> Bookingmodel = new List<Booking>();
            var booking = new Booking();
            booking.PNR = "PNR" + Guid.NewGuid().ToString();
            booking.BookingId = Guid.NewGuid();
            booking.Name = model.Name;
            booking.EmailId = model.Email;
            booking.Meal = (short)model.MealPreference;
            booking.NumberOfSeats = model.NoOfSeats;
            booking.CreatedDate = DateTime.Now;
            booking.UpdatedDate = DateTime.Now;
            booking.InventoryId = model.InvOnewayId;
            booking.Address = model.Address;
            booking.MobileNo = model.MobileNo;
            if (model.DiscountApplied)
            {
                booking.Discount = _context.Discounts.FirstOrDefault(x => x.DiscountCode == model.DiscountCode).Amount.ToString();
            }

            //booking.AirlineId = model.AirlineId;
            booking.IsActive = true;
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            Bookingmodel.Add(booking);
            //Return Flight
            if (model.InvReturnId != Guid.Empty)
            {
                booking = new Booking();
                booking.BookingId = Guid.NewGuid();
                booking.PNR = "PNR" + Guid.NewGuid().ToString();
                booking.Name = model.Name;
                booking.EmailId = model.Email;
                booking.Meal = (short)model.MealPreference;
                booking.NumberOfSeats = model.NoOfSeats;
                booking.CreatedDate = DateTime.Now;
                booking.UpdatedDate = DateTime.Now;
                booking.InventoryId = model.InvReturnId;
                booking.Address = model.Address;
                booking.MobileNo = model.MobileNo;
                if (model.DiscountApplied)
                {
                    booking.Discount = _context.Discounts.FirstOrDefault(x => x.DiscountCode == model.DiscountCode).Amount.ToString();
                }
                booking.IsActive = true;
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                Bookingmodel.Add(booking);
            }

            //foreach (var item in model.passenger)
            //{
            //    _context.Passengers.Add(new Passenger { Name = item.Name, Gender = item.Gender, Age = item.Age, BookingId = booking.BookingId });
            //}
            //_context.SaveChanges();
            return Bookingmodel;
        }
        public List<Booking> BookingHistory(string EmailId)
        {
            return _context.Bookings.Include(x => x.Inventory)
                .ThenInclude(x => x.Airline)
                .Include(x => x.Inventory.Source)
                .Include(x => x.Inventory.Destination)
                .Where(x => x.EmailId == EmailId && x.IsActive == true).ToList();
        }
        public List<Booking> BookingHistory()
        {
            return _context.Bookings.Include(x => x.Inventory)
                .ThenInclude(x => x.Airline)
                .Include(x => x.Inventory.Source)
                .Include(x => x.Inventory.Destination)
                .Where(x => x.IsActive == true).ToList();
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
            return _context.Bookings.Include(x => x.Inventory).Include(x => x.Inventory.Airline)
                .Include(x => x.Inventory.Source)
                .Include(x => x.Inventory.Destination)
                .Where(x => x.PNR == PNR && x.IsActive == true).FirstOrDefault();
        }
    }
}
