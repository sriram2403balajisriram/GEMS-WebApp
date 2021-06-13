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
        public static string Loginname;
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
        [HttpPost]
        public bool Authenticate(UserCredentials usercred)
        {
            if(string.IsNullOrEmpty(usercred.Username) || string.IsNullOrEmpty(usercred.Password))
            {
                return false;
            }
            else
            {
                Loginname = usercred.Username;
                var token = _jwtauthenticationmanager.Authenticate(usercred.Username, usercred.Password);
                if (token == null)
                    return false;
                return true;
            }
            //return View();
        }
    }
}
