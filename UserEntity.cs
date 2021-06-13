using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEMS_Cloud.Models
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Trialuser { get; set; }
        public string Customer { get; set; }
        public string role { get; set; }
    }
}
