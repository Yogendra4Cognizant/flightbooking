using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal TicketCost { get; set; }
        public int Rows { get; set; }
        public Int16 foodType { get; set; }
        public Guid AirlineId { get; set; }
        public Airline Airline { get; set; }
        public Guid SourceId { get; set; }
        public Airport Source { get; set; }
        public Guid DestinationId { get; set; }
        public Airport Destination { get; set; }
    }
}
