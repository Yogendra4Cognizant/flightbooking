using FlightBooking.Interface;
using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Service
{
    public class AirPortRepository : IAirPortRepository
    {
        private FlightDbContext _context;
        public AirPortRepository(FlightDbContext _context)
        {
            this._context = _context;
        }
        public Airport GetAirPortById(Guid id)
        {
            return _context.Airports.FirstOrDefault(x => x.AirportId == id);

        }

        public List<Airport> GetAirPortList()
        {
            return _context.Airports.ToList();
        }

        public Airport SaveAirPort(Airport model)
        {
            _context.Airports.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
