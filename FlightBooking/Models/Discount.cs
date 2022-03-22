using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class Discount
    {
        public Guid DiscountId { get; set; }
        public string DiscountCode { get; set; }
        [NotMapped]
        public bool DiscountApplied { get; set; }
        public int Amount { get; set; }
    }
}
