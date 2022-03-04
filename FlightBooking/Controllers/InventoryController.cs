using FlightBooking.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public readonly IInventoryRepository _repository;
        public InventoryController(IInventoryRepository _repository)
        {
            this._repository = _repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _repository.GetInventoryList();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _repository.GetInventoryById(id);
            return Ok(res);
        }
    }
}
