using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.ViewModels
{
    public class Unit
    {
        public string Name { get; set; }
        public double ConversionFactor { get; set; }  // This could be used to calculate conversions
    }

    public class ConversionType
    {
        public string Name { get; set; }
        public ObservableCollection<Unit> Units { get; set; }

        public ConversionType()
        {
            Units = new ObservableCollection<Unit>();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ConversionType> ConversionTypes { get; set; }

        public MainViewModel()
        {
            ConversionTypes = new ObservableCollection<ConversionType>
        {
            new ConversionType { Name = "Length", Units = new ObservableCollection<Unit> {
                new Unit { Name = "Meters", ConversionFactor = 1 },
                new Unit { Name = "Kilometers", ConversionFactor = 0.001 }
            }},
            new ConversionType { Name = "Time", Units = new ObservableCollection<Unit> {
                new Unit { Name = "Seconds", ConversionFactor = 1 },
                new Unit { Name = "Minutes", ConversionFactor = 1.0 / 60 }
            }},
            // Add other conversion types similarly
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
