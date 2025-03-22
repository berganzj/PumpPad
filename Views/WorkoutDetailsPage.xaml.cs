using Microsoft.Maui.Controls;
using PumpPad.Models;
using PumpPad.Services;
using SQLite;
using System.Collections.Generic;

namespace PumpPad
{
    public partial class WorkoutDetailsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly string _workoutPresetName;

        public WorkoutDetailsPage(WorkoutPreset workoutPreset)
        {
            InitializeComponent();
            _databaseService = new DatabaseService(FileAccessHelper.GetLocalFilePath("workouts.db3"));
            _workoutPresetName = workoutPreset.Name;
            PopulateGrid(workoutPreset);
        }

        private void PopulateGrid(WorkoutPreset workoutPreset)
        {
            // Add column definitions
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                for (int i = 0; i < workoutPreset.Exercises[0].Sets; i++)
                {
                    WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                }

                // Add header row
                WorkoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var exerciseLabel = new Label { Text = "Exercise" };
                WorkoutGrid.Children.Add(exerciseLabel);
                Grid.SetRow(exerciseLabel, 0);
                Grid.SetColumn(exerciseLabel, 0);

                for (int i = 0; i < workoutPreset.Exercises[0].Sets; i++)
                {
                    var setLabel = new Label { Text = $"Set {i + 1}" };
                    WorkoutGrid.Children.Add(setLabel);
                    Grid.SetRow(setLabel, 0);
                    Grid.SetColumn(setLabel, i * 2 + 1);
                }

                // Add exercise rows
                for (int i = 0; i < workoutPreset.Exercises.Count; i++)
                {
                    WorkoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var exerciseNameLabel = new Label { Text = workoutPreset.Exercises[i].Name };
                    WorkoutGrid.Children.Add(exerciseNameLabel);
                    Grid.SetRow(exerciseNameLabel, i + 1);
                    Grid.SetColumn(exerciseNameLabel, 0);

                    for (int j = 0; j < workoutPreset.Exercises[i].Sets; j++)
                    {
                        var setEntry = new Entry { Placeholder = "Weight" };
                        WorkoutGrid.Children.Add(setEntry);
                        Grid.SetRow(setEntry, i + 1);
                        Grid.SetColumn(setEntry, j * 2 + 1);

                        var repsEntry = new Entry { Placeholder = "Reps" };
                        WorkoutGrid.Children.Add(repsEntry);
                        Grid.SetRow(repsEntry, i + 1);
                        Grid.SetColumn(repsEntry, j * 2 + 2);
                    }
                }
            }
            else
            {
                // Handle other platforms if necessary
            }
        }

        private async void OnSaveWorkoutClicked(object sender, EventArgs e)
        {
            var workoutSession = new WorkoutSession
            {
                WorkoutPresetName = _workoutPresetName,
                Timestamp = DateTime.Now
            };

            await _databaseService.SaveWorkoutSessionAsync(workoutSession);

            var workoutExercises = new List<WorkoutExercise>();

            foreach (var row in Enumerable.Range(1, WorkoutGrid.RowDefinitions.Count - 1))
            {
                var exerciseLabel = WorkoutGrid.Children.OfType<Label>().FirstOrDefault(c => Grid.GetRow(c) == row && Grid.GetColumn(c) == 0);
                if (exerciseLabel == null)
                {
                    continue; // Skip this row if no exercise name is found
                }

                var exerciseName = exerciseLabel.Text;
                var sets = (WorkoutGrid.ColumnDefinitions.Count - 1) / 2;

                var workoutExercise = new WorkoutExercise
                {
                    WorkoutSessionId = workoutSession.Id,
                    ExerciseName = exerciseName
                };

                await _databaseService.SaveWorkoutExerciseAsync(workoutExercise);

                for (int setIndex = 0; setIndex < sets; setIndex++)
                {
                    var weightEntry = WorkoutGrid.Children.OfType<Entry>().FirstOrDefault(c => Grid.GetRow(c) == row && Grid.GetColumn(c) == setIndex * 2 + 1);
                    var repsEntry = WorkoutGrid.Children.OfType<Entry>().FirstOrDefault(c => Grid.GetRow(c) == row && Grid.GetColumn(c) == setIndex * 2 + 2);

                    if (weightEntry != null && repsEntry != null && int.TryParse(repsEntry.Text, out int reps))
                    {
                        var workoutSet = new WorkoutSet
                        {
                            WorkoutExerciseId = workoutExercise.Id,
                            SetIndex = setIndex + 1,
                            Reps = reps,
                            Weight = weightEntry.Text
                        };

                        await _databaseService.SaveWorkoutSetAsync(workoutSet);
                    }
                }
            }

            await DisplayAlert("Success", "Workout saved successfully!", "OK");
        }

        // Example method to start a workout
        private async void StartWorkout(int workoutSessionId)
        {
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                await Navigation.PushAsync(new WorkoutSessionDetailsPage(workoutSessionId, isReadOnly: false));
            }
            else
            {
                // Handle other platforms if necessary
            }
        }
    }
}

