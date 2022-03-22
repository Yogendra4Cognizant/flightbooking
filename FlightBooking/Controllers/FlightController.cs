using FlightBooking.Interface;
using FlightBooking.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public readonly IFlightRepository _repository;
        public FlightController(IFlightRepository _repository)
        {
            this._repository = _repository;
        }
        [HttpPost]
        [Route("SearchFlight")]
        public IActionResult Post(SearchViewModel model)
        {
            var res = _repository.SearchFlight(model);
            if (res.Count == 0)
                return NotFound("!Flight Not found");

            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(BookingViewModel model)
        {
            var res = _repository.BookFlight(model);
            if (res == null)
                return Unauthorized("!Some error Occurred");

            return Ok(res);
        }
        [HttpGet]
        [Route("ticket/{PNRNo}")]
        public IActionResult Ticket(string PNRNo)
        {
            var res = _repository.SearchBookedFlight(PNRNo);
            if (res == null)
                return NotFound("!Not found");

            return Ok(res);
        }
        [HttpGet]
        [Route("history/{EmailId}")]
        public IActionResult History(string EmailId)
        {
            var res = _repository.BookingHistory(EmailId);

            if (res == null)
                return NotFound("!Not found");

            return Ok(res);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _repository.BookingHistory();

            if (res == null)
                return NotFound("!Not found");

            return Ok(res);
        }
        [HttpGet]
        [Route("cancel/{PNR}")]
        public IActionResult Cancel(string PNR)
        {
            var res = _repository.CancelBooking(PNR);

            return Ok(res);
        }
    }
}
