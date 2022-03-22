using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Interface
{
    public interface IAirPortRepository
    {
        List<Airport> GetAirPortList();
        Airport GetAirPortById(Guid id);
        Airport SaveAirPort(Airport id);
    }
}
