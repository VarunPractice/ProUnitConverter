using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProUnitConverter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<string> MainUnits { get; set; } // Energy, Time, Distance
        public ObservableCollection<string> SubUnits1 { get; set; } // Subunits for the selected main unit in ComboBox1
        public ObservableCollection<string> SubUnits2 { get; set; } // Subunits for the selected main unit in ComboBox2

        private string _selectedMainUnit1;
        private string _selectedMainUnit2;

        public string SelectedMainUnit1
        {
            get => _selectedMainUnit1;
            set
            {
                Set(ref _selectedMainUnit1, value);
                UpdateSubUnits1();
            }
        }

        public string SelectedMainUnit2
        {
            get => _selectedMainUnit2;
            set
            {
                Set(ref _selectedMainUnit2, value);
                UpdateSubUnits2();
            }
        }
        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public string SelectedSubunit1 { get; set; }
        public string SelectedSubunit2 { get; set; }

        public string InputValue { get; set; }
        public string OutputValue { get; set; }

        public RelayCommand ConvertCommand { get; private set; }

        public MainViewModel()
        {
            MainUnits = new ObservableCollection<string> { "Energy", "Time", "Distance" };
            SubUnits1 = new ObservableCollection<string>();
            SubUnits2 = new ObservableCollection<string>();
            ConvertCommand = new RelayCommand(PerformConversion);
        }

        private void UpdateSubUnits1()
        {
            SubUnits1.Clear();
            foreach (var subunit in GetSubUnitsForCategory(SelectedMainUnit1))
            {
                SubUnits1.Add(subunit);
            }
        }

        private void UpdateSubUnits2()
        {
            SubUnits2.Clear();
            foreach (var subunit in GetSubUnitsForCategory(SelectedMainUnit2))
            {
                SubUnits2.Add(subunit);
            }
        }

        private IEnumerable<string> GetSubUnitsForCategory(string category)
        {

            switch (category)
            {
                case "Energy":
                    return new List<string> { "Joules", "Kilowatt-hours" };
                case "Time":
                    return new List<string> { "Seconds", "Minutes", "Hours" };
                case "Distance":
                    return new List<string> { "Meters", "Kilometers" };
                default:
                    return new List<string>();
            }
        }

        private void PerformConversion()
        {
            // Placeholder conversion logic
            OutputValue = $"Converted {InputValue} from {SelectedSubunit1} to {SelectedSubunit2}";
            RaisePropertyChanged(nameof(OutputValue));
        }
    }
}
