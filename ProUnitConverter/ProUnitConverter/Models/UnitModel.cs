using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.Models
{
    public class UnitModel
    {
        public int UnitID { get; set; }
        public string Name { get; set; }
        public double ConversionFactor { get; set; }  

        public List<SubunitModel> Subunits { get; set; }    
    }
    public class ConversionType
    {
        public string Name { get; set; }
        public ObservableCollection<UnitModel> Units { get; set; }

        public ConversionType()
        {
            Units = new ObservableCollection<UnitModel>();
        }
    }
}
