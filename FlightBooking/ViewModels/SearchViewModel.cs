using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.ViewModels
{
    public class SearchViewModel
    {
        public int TripType { get; set; }
        public Guid SourceId { get; set; }
        public Guid DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int NumberofSeats { get; set; }
        public int TravelClass { get; set; }
    }
}
