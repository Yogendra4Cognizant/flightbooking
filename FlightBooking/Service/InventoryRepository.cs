using FlightBooking.Interface;
using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Service
{
    public class InventoryRepository : IInventoryRepository
    {
        private FlightDbContext _context;
        public InventoryRepository(FlightDbContext _context)
        {
            this._context = _context;
        }
        public Inventory GetInventoryById(Guid id)
        {
            return _context.Inventories.FirstOrDefault(x => x.InventoryId == id);

        }

        public List<Inventory> GetInventoryList()
        {
            var res = _context.Inventories.Include(x => x.Airline).Include(x => x.Source).Include(x => x.Destination).ToList();
            res.ForEach(x =>
            {
                x.TotalHour = getDateDifference(x.EndDate , x.StartDate);
            });
            return res;
        }
        string getDateDifference(DateTime endDate, DateTime startDate)
        {
            TimeSpan diffDate = endDate.Subtract(startDate);
            return diffDate.Hours + "Hr " + diffDate.Minutes + "min";
        }

        public Inventory SaveInventory(Inventory model)
        {
            _context.Inventories.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
