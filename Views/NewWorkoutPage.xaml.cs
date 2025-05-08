using Microsoft.Maui.Controls;
using PumpPad.Models;
using System.Collections.Generic;
using System.Linq;

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
                    var workoutDetails = preset.Exercises.Select(exercise => new
                    {
                        exercise.Name,
                        exercise.Sets,
                        Reps = string.Join(", ", exercise.Reps),
                        exercise.Instruction
                    }).ToList();

                    WorkoutDetailsListView.ItemsSource = workoutDetails;
                    WorkoutDetailsListView.IsVisible = true;
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
                    await Navigation.PushAsync(new InputWorkoutDetailsPage(preset));
                }
            }
            else
            {
                await DisplayAlert("Error", "No workout selected", "OK");
            }
        }
    }
}

