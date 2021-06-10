using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEMS_Cloud
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string Username, string Password);
    }
}
