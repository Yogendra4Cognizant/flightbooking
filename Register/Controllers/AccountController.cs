using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Models;
using Register.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository _repository;
        public AccountController(IUserRepository _repository)
        {
            this._repository = _repository;
        }
        [HttpGet]
        public IActionResult LogIn(User user)
        {
            var res = _repository.GetUser(user);
            return Ok(res);
        }
    }
}
