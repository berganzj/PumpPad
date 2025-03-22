using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PumpPad.Models;

namespace PumpPad.ViewModels
{
    public class NewWorkoutViewModel : BaseViewModel
    {
        public ObservableCollection<WorkoutPreset> WorkoutPresets { get; set; }
        private WorkoutPreset _selectedWorkoutPreset;

        public WorkoutPreset SelectedWorkoutPreset
        {
            get => _selectedWorkoutPreset;
            set
            {
                _selectedWorkoutPreset = value;
                OnPropertyChanged();
                OnWorkoutSelected();
            }
        }

        public NewWorkoutViewModel()
        {
            WorkoutPresets = new ObservableCollection<WorkoutPreset>(WorkoutPreset.GetPresets());
            _selectedWorkoutPreset = WorkoutPresets.FirstOrDefault(); // Initialize _selectedWorkoutPreset
        }

        private void OnWorkoutSelected()
        {
            // Handle workout selection logic here
        }
    }
}
