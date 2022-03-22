using FlightBooking.Interface;
using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Service
{
    public class DiscountRepository : IDiscountRepository
    {
        private FlightDbContext _context;
        public DiscountRepository(FlightDbContext _context)
        {
            this._context = _context;
        }
        public bool GetDiscountById(string DiscountCode)
        {
            return _context.Discounts.Any(x => x.DiscountCode == DiscountCode);

        }

        public List<Discount> GetDiscountList()
        {
            return _context.Discounts.ToList();
        }

        public Discount SaveDiscount(Discount model)
        {
            _context.Discounts.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
