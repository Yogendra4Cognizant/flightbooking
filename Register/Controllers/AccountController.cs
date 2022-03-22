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
        private IJwtauthManager _repository;
        private IUserRepository _userrepository;
        public AccountController(IJwtauthManager _repository, IUserRepository _userrepository)
        {
            this._repository = _repository;
            this._userrepository = _userrepository;
        }
        [HttpPost]
        public IActionResult LogIn([FromForm] User user)
        {
            var usermodel = _userrepository.GetUser(user);
            if (usermodel != null)
            {
                var token = _repository.Authenticate(usermodel);
                if (token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(new { token, usermodel });
                }
            }
            else
            {
                return Unauthorized();

            }

        }
    }
}
