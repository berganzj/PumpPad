using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace PumpPad
{
    public partial class WorkoutSessionDetailsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly int _workoutSessionId;

        public WorkoutSessionDetailsPage(int workoutSessionId)
        {
            InitializeComponent();
            _databaseService = new DatabaseService(FileAccessHelper.GetLocalFilePath("workouts.db3"));
            _workoutSessionId = workoutSessionId;
            LoadWorkoutExercises();
        }

        private async void LoadWorkoutExercises()
        {
            var workoutExercises = await _databaseService.GetWorkoutExercisesAsync(_workoutSessionId);
            PopulateGrid(workoutExercises);
        }

        private void PopulateGrid(List<WorkoutExercise> workoutExercises)
        {
            // Add column definitions
            WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            for (int i = 0; i < workoutExercises[0].Sets; i++)
            {
                WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Add column for reps
            }

            // Add header row
            WorkoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            var exerciseLabel = new Label { Text = "Exercise" };
            WorkoutGrid.Children.Add(exerciseLabel);
            Grid.SetRow(exerciseLabel, 0);
            Grid.SetColumn(exerciseLabel, 0);

            for (int i = 0; i < workoutExercises[0].Sets; i++)
            {
                var setLabel = new Label { Text = $"Set {i + 1}" };
                WorkoutGrid.Children.Add(setLabel);
                Grid.SetRow(setLabel, 0);
                Grid.SetColumn(setLabel, i * 2 + 1);
            }

            // Add exercise rows
            for (int i = 0; i < workoutExercises.Count; i++)
            {
                WorkoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var exerciseNameLabel = new Label { Text = workoutExercises[i].ExerciseName };
                WorkoutGrid.Children.Add(exerciseNameLabel);
                Grid.SetRow(exerciseNameLabel, i + 1);
                Grid.SetColumn(exerciseNameLabel, 0);

                for (int j = 0; j < workoutExercises[i].Sets; j++)
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
    }
}
