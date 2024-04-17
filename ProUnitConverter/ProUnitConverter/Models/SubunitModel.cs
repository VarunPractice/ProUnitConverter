using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.Models
{
    [Table("Subunits")]
    public class SubunitModel
    {
        public int SubunitId { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; } // This corresponds to the UnitID in UnitModel
    }
}
