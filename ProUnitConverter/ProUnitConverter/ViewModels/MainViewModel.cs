using GalaSoft.MvvmLight;
using ProUnitConverter.Models;
using System.Collections.ObjectModel;

namespace ProUnitConverter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<UnitModel> MainUnits { get; private set; }
        private UnitModel _selectedMainUnit1;
        private SubunitModel _selectedSubUnit1;

        public UnitModel SelectedMainUnit1
        {
            get => _selectedMainUnit1;
            set
            {
                if (_selectedMainUnit1 != value)
                {
                    _selectedMainUnit1 = value;
                    RaisePropertyChanged(nameof(SelectedMainUnit1));
                    UpdateSubUnits1();  // Update subunits when a new main unit is selected
                }
            }
        }

        public SubunitModel SelectedSubUnit1
        {
            get => _selectedSubUnit1;
            set
            {
                _selectedSubUnit1 = value;
                RaisePropertyChanged(nameof(SelectedSubUnit1));
            }
        }

        public ObservableCollection<SubunitModel> SubUnits1 { get; private set; }

        public MainViewModel()
        {
            MainUnits = DAL.UnitDAL.Instance.GetAllUnits();
            SubUnits1 = new ObservableCollection<SubunitModel>();
            if (MainUnits.Any())
            {
                SelectedMainUnit1 = MainUnits.First();  // Automatically select the first main unit if available
            }
        }

        private void UpdateSubUnits1()
        {
            SubUnits1.Clear();  // Clear existing subunits
            if (_selectedMainUnit1 != null && _selectedMainUnit1.Subunits != null)
            {
                // Add only the subunits that belong to the selected main unit
                foreach (var subunit in _selectedMainUnit1.Subunits)
                {
                    SubUnits1.Add(subunit);
                }
            }
            RaisePropertyChanged(nameof(SubUnits1));  // Notify UI of the update
        }
    }


}
