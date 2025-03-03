using Microsoft.Maui.Controls;
using System.Collections.Generic;

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

            if (WorkoutPicker.SelectedItem != null)
            {
                string selectedWorkout = WorkoutPicker.SelectedItem?.ToString() ?? string.Empty;
                var preset = WorkoutPreset.GetPresets().Find(p => p.Name == selectedWorkout);
                if (preset != null)
                {
                    List<string> workoutDetails = new List<string>();
                    for (int i = 0; i < preset.Exercises.Count; i++)
                    {
                        workoutDetails.Add($"{preset.Exercises[i]}: {preset.Sets[i]} sets of {string.Join(", ", preset.Reps)} reps");
                    }
                    WorkoutDetailsListView.ItemsSource = workoutDetails;
                    WorkoutDetailsListView.IsVisible = true;

                    InstructionLabel.Text = string.Join("\n", preset.Instructions);
                    InstructionLabel.IsVisible = true;
                }
            }
        }

        private async void OnStartWorkoutClicked(object sender, EventArgs e)
        {
            if (WorkoutPicker.SelectedItem is not null)
            {
                string selectedWorkout = WorkoutPicker.SelectedItem.ToString()!;
                var preset = WorkoutPreset.GetPresets().Find(p => p.Name == selectedWorkout);
                if (preset != null)
                {
                    // Navigate to the workout details page
                    await Navigation.PushAsync(new WorkoutDetailsPage(preset));
                }
            }
            else
            {
                await DisplayAlert("Error", "No workout selected", "OK");
            }
        }
    }
}
