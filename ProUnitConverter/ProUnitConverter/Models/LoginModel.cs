using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.Models
{
    public class LoginModel : ILoginModel
    {
        public int Id { get; set; }
        public string LoginId { get ; set ; }
        public string LoginPassword { get; set ; }
    }
}
