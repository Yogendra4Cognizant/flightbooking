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
    public class AirLineController : ControllerBase
    {
        public readonly IAirlineRepository _repository;
        public AirLineController(IAirlineRepository _repository)
        {
            this._repository = _repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _repository.GetAirlineList();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _repository.GetAirlineById(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post([FromForm]Airline Model)
        {
            Model.Logo = Request.Scheme + "://" + Request.Host;
            var res = _repository.SaveAirline(Model);
            return Created(HttpContext.Request.Scheme + "://" +
                    HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + res.AirlineId, res);
        }
    }
}
