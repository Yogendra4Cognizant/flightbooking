using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Interface
{
    public interface IAirlineRepository
    {
        List<Airline> GetAirlineList();
        Airline GetAirlineById(Guid id);
        Airline SaveAirline(Airline id);
    }
}
