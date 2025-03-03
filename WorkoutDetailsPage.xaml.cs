using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace PumpPad
{
    public partial class WorkoutDetailsPage : ContentPage
    {
        public WorkoutDetailsPage(WorkoutPreset workoutPreset)
        {
            InitializeComponent();
            PopulateGrid(workoutPreset);
        }

        private void PopulateGrid(WorkoutPreset workoutPreset)
        {
            // Add column definitions
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
                var weightLabel = new Label { Text = $"Set {i + 1} Weight" };
                WorkoutGrid.Children.Add(weightLabel);
                Grid.SetRow(weightLabel, 0);
                Grid.SetColumn(weightLabel, i * 2 + 1);

                var repsLabel = new Label { Text = $"Set {i + 1} Reps" };
                WorkoutGrid.Children.Add(repsLabel);
                Grid.SetRow(repsLabel, 0);
                Grid.SetColumn(repsLabel, i * 2 + 2);
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
                    var weightEntry = new Entry { Placeholder = "Weight" };
                    WorkoutGrid.Children.Add(weightEntry);
                    Grid.SetRow(weightEntry, i + 1);
                    Grid.SetColumn(weightEntry, j * 2 + 1);

                    var repsLabel = new Label { Text = workoutPreset.Exercises[i].Reps[j].ToString() };
                    WorkoutGrid.Children.Add(repsLabel);
                    Grid.SetRow(repsLabel, i + 1);
                    Grid.SetColumn(repsLabel, j * 2 + 2);
                }
            }
        }
    }
}

