using FlightBooking.Interface;
using FlightBooking.Models;
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
    public class AirportController : ControllerBase
    {
        public readonly IAirPortRepository _repository;
        public AirportController(IAirPortRepository _repository)
        {
            this._repository = _repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _repository.GetAirPortList();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _repository.GetAirPortById(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post([FromForm]Airport Model)
        {
            var res = _repository.SaveAirPort(Model);
            return Created(HttpContext.Request.Scheme + "://" +
                    HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + res.AirportId, res);
        }
    }
}
