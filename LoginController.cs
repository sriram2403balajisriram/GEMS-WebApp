using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GEMS_Cloud.Models;
using Microsoft.AspNetCore.Authorization;

namespace GEMS_Cloud.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly IJwtAuthenticationManager _jwtauthenticationmanager;
        public LoginController(IJwtAuthenticationManager jwtauthenticationmanager)
        {
            _jwtauthenticationmanager = jwtauthenticationmanager;
        }
        [AllowAnonymous]
        public IActionResult Signup()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserCredentials usercred)
        {
            var token = _jwtauthenticationmanager.Authenticate(usercred.Username,usercred.Password);
            if (token == null)
                return Unauthorized();  
            return Ok(token);
        }
    }
}
