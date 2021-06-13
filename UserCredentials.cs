using System;
using System.ComponentModel.DataAnnotations;

namespace GEMS_Cloud.Models
{
    public class UserCredentials
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Roles
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
    }
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string CustName { get; set; }
    }
    public class UserDetails
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Trialuser { get; set; }
        public int Cid { get; set; }
        public int Roleid { get; set; }
    }
}
