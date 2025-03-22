using Microsoft.Maui.Controls;
using PumpPad.ViewModels;
using PumpPad.Models;
using PumpPad.Services;

namespace PumpPad
{
    public partial class WorkoutSessionDetailsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly int _sessionId;
        private readonly bool _isReadOnly;

        public WorkoutSessionDetailsPage(int sessionId, bool isReadOnly)
        {
            InitializeComponent();
            _sessionId = sessionId;
            _isReadOnly = isReadOnly;
            _databaseService = new DatabaseService(FileAccessHelper.GetLocalFilePath("workouts.db3"));
            LoadWorkoutSessionDetails();
        }

        private async void LoadWorkoutSessionDetails()
        {
            var sessionDetails = await _databaseService.GetWorkoutSessionsAsync();
            var sessionDetail = sessionDetails.FirstOrDefault(s => s.Id == _sessionId);

            if (sessionDetail != null)
            {
                var workoutExercises = await _databaseService.GetWorkoutExercisesAsync(_sessionId);
                PopulateGrid(workoutExercises);
            }
        }

        private void PopulateGrid(List<WorkoutExercise> workoutExercises)
        {
            WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            for (int i = 0; i < workoutExercises.Max(e => e.WorkoutSets.Count); i++)
            {
                WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            WorkoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            var exerciseLabel = new Label { Text = "Exercise" };
            WorkoutGrid.Children.Add(exerciseLabel);
            Grid.SetRow(exerciseLabel, 0);
            Grid.SetColumn(exerciseLabel, 0);

            for (int i = 0; i < workoutExercises.Max(e => e.WorkoutSets.Count); i++)
            {
                var setLabel = new Label { Text = $"Set {i + 1}" };
                WorkoutGrid.Children.Add(setLabel);
                Grid.SetRow(setLabel, 0);
                Grid.SetColumn(setLabel, i * 2 + 1);
            }

            for (int i = 0; i < workoutExercises.Count; i++)
            {
                WorkoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var exerciseNameLabel = new Label { Text = workoutExercises[i].ExerciseName };
                WorkoutGrid.Children.Add(exerciseNameLabel);
                Grid.SetRow(exerciseNameLabel, i + 1);
                Grid.SetColumn(exerciseNameLabel, 0);

                for (int j = 0; j < workoutExercises[i].WorkoutSets.Count; j++)
                {
                    var setEntry = new Entry { Text = workoutExercises[i].WorkoutSets[j].Weight, IsReadOnly = _isReadOnly };
                    WorkoutGrid.Children.Add(setEntry);
                    Grid.SetRow(setEntry, i + 1);
                    Grid.SetColumn(setEntry, j * 2 + 1);

                    var repsEntry = new Entry { Text = workoutExercises[i].WorkoutSets[j].Reps.ToString(), IsReadOnly = _isReadOnly };
                    WorkoutGrid.Children.Add(repsEntry);
                    Grid.SetRow(repsEntry, i + 1);
                    Grid.SetColumn(repsEntry, j * 2 + 2);
                }
            }
        }
    }
}