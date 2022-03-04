using FlightBooking.Interface;
using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Inventories.ToList();
        }

        public void SaveInventory(Inventory model)
        {
            _context.Inventories.Add(model);
            _context.SaveChanges();
        }
    }
}
