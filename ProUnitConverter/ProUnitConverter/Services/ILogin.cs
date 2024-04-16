using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.Services
{
    public interface ILogin
    {
        bool AuthenticateUser(string username, string password);
    }
}
