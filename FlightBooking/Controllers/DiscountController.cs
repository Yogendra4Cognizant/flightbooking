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
    public class DiscountController : ControllerBase
    {
        public readonly IDiscountRepository _repository;
        public DiscountController(IDiscountRepository _repository)
        {
            this._repository = _repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _repository.GetDiscountList();
            return Ok(res);
        }

        [HttpGet]
        [Route("{DiscountCode}")]
        public IActionResult Get(string DiscountCode)
        {
            var res = _repository.GetDiscountById(DiscountCode);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(Discount Model)
        {
            var res = _repository.SaveDiscount(Model);
            return Created(HttpContext.Request.Scheme + "://" +
                    HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + res.DiscountId, res);
        }
    }
}
