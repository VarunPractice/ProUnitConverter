using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.Models
{
   public interface ILoginModel
    {
          int Id { get; set; }
          string LoginId { get; set; }
          string LoginPassword { get; set; }
    }
}
