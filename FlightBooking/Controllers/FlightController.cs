using FlightBooking.Service;
using FlightBooking.ViewModels;
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
    public class FlightController : ControllerBase
    {
        public readonly IFlightRepository _repository;
        public FlightController(IFlightRepository _repository)
        {
            this._repository = _repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");
        }

        //[HttpGet]
        //public IActionResult Get(SearchViewModel model)
        //{
        //    var res = _repository.SearchFlight(model);
        //    return Ok(res);
        //}

        //[HttpPost]
        //public IActionResult Post(List<BookingViewModel> model)
        //{
        //    var res = _repository.BookFlight(model);
        //    return Ok(res);
        //}
        //[HttpGet]
        //[Route("{PNRNo}")]
        //public IActionResult Ticket(string PNRNo)
        //{
        //    var res = _repository.SearchBookedFlight(PNRNo);
        //    return Ok(res);
        //}
        //[HttpGet]
        //[Route("{EmailId}")]
        //public IActionResult History(string EmailId)
        //{
        //    var res = _repository.BookingHistory(EmailId);
        //    return Ok(res);
        //}
        //[HttpGet]
        //[Route("{PNR}")]
        //public IActionResult Cancel(string PNR)
        //{
        //    var res = _repository.CancelBooking(PNR);
        //    return Ok(res);
        //}
    }
}
