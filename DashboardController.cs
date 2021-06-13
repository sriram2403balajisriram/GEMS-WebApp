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
    public class DashboardController : Controller
    {
        public ViewResult Usermanagement()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public List<UserEntity> getUserDetails()
        {
            List<UserEntity> users;
            using (var context = new MyDbContext())
            {
                users = (from user in context.userDetails
                         join role in context.Roles on user.Roleid equals role.ID
                         join cust in context.Customers on user.Cid equals cust.ID
                         select new UserEntity { Firstname = user.Firstname, Lastname = user.Lastname, Username = user.Email, Email = user.Email, Trialuser = user.Trialuser, Customer = cust.CustName, role = role.RoleName }).ToList();
            }
            return users;
        }
        [Authorize]
        [HttpPost]
        public List<UserEntity> saveUserDetails(UserDetails userdetails)
        {
            List<UserEntity> users;
            using (var context = new MyDbContext())
            {
                if (userdetails.ID > 0)
                {
                    context.userDetails.Update(userdetails);
                }
                else
                {
                    context.userDetails.Add(userdetails);
                }
                context.SaveChanges();
            }
            using (var context = new MyDbContext())
            {
                users = (from user in context.userDetails
                         join role in context.Roles on user.Roleid equals role.ID
                         join cust in context.Customers on user.Cid equals cust.ID
                         select new UserEntity { Firstname = user.Firstname, Lastname = user.Lastname, Username = user.Email, Email = user.Email, Trialuser = user.Trialuser, Customer = cust.CustName, role = role.RoleName }).ToList();
            }
            return users;
        }
        [HttpDelete]
        public List<UserEntity> deleteUserDetails(UserDetails userdetails)
        {
            List<UserEntity> users;
            using (var context = new MyDbContext())
            {
                context.userDetails.Remove(userdetails);
                context.SaveChanges();
            }
            using (var context = new MyDbContext())
            {
                users = (from user in context.userDetails
                          join role in context.Roles on user.Roleid equals role.ID
                          join cust in context.Customers on user.Cid equals cust.ID
                          select new UserEntity { Firstname = user.Firstname, Lastname = user.Lastname, Username = user.Email, Email = user.Email, Trialuser = user.Trialuser, Customer = cust.CustName, role = role.RoleName }).ToList();
            }
            return users;
        }
    }
}
