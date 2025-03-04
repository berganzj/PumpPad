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
                Grid.SetColumn(setLabel, i + 1);
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
                    Grid.SetColumn(setEntry, j + 1);
                }
            }
        }
    }
}

