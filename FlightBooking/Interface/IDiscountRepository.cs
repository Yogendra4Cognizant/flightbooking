using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Interface
{
    public interface IDiscountRepository
    {
        List<Discount> GetDiscountList();
        bool GetDiscountById(string DiscountCode);
        Discount SaveDiscount(Discount id);
    }
}
