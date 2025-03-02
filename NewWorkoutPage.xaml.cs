using Microsoft.Maui.Controls;

namespace PumpPad
{
    public partial class NewWorkoutPage : ContentPage
    {
        public bool IsWorkoutSelected { get; set; }

        public NewWorkoutPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnWorkoutSelected(object sender, EventArgs e)
        {
            IsWorkoutSelected = WorkoutPicker.SelectedIndex != -1;
            OnPropertyChanged(nameof(IsWorkoutSelected));
        }

        private void OnStartWorkoutClicked(object sender, EventArgs e)
        {
            if (WorkoutPicker.SelectedItem is not null)
            {
                string selectedWorkout = WorkoutPicker.SelectedItem.ToString()!;
                // Navigate to the workout details page or start the workout
                DisplayAlert("Workout Selected", $"You selected: {selectedWorkout}", "OK");
            }
            else
            {
                DisplayAlert("Error", "No workout selected", "OK");
            }
        }
    }
}

