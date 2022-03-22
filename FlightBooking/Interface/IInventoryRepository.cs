using FlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Interface
{
    public interface IInventoryRepository
    {
        List<Inventory> GetInventoryList();
        Inventory GetInventoryById(Guid id);
        Inventory SaveInventory(Inventory id);
    }
}
