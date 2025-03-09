using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PumpPad.Models;
using PumpPad.Services;

namespace PumpPad.ViewModels
{
    public class ReviewWorkoutsViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;

        public ObservableCollection<WorkoutData> Workouts { get; set; }

        public ReviewWorkoutsViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            Workouts = new ObservableCollection<WorkoutData>();
            LoadWorkoutsCommand = new Command(async () => await LoadWorkouts());
        }

        public ICommand LoadWorkoutsCommand { get; }

        private async Task LoadWorkouts()
        {
            int workoutSessionId = GetCurrentWorkoutSessionId(); // Assuming you have a method to get the current workout session ID
            var workoutExercises = await _databaseService.GetWorkoutExercisesAsync(workoutSessionId);
            Workouts.Clear();
            foreach (var workoutExercise in workoutExercises)
            {
                var workoutData = new WorkoutData
                {
                    Id = workoutExercise.Id,
                    ExerciseName = workoutExercise.ExerciseName,
                    WorkoutPresetName = "Default Preset", // Assuming a default value or you can fetch the actual preset name
                    Sets = 0, // Assuming default value or you can fetch the actual sets
                    Reps = 0, // Assuming default value or you can fetch the actual reps
                    Timestamp = DateTime.Now // Assuming current timestamp or you can fetch the actual timestamp
                };
                Workouts.Add(workoutData);
            }
        }

        private int GetCurrentWorkoutSessionId()
        {
            // Implement this method to return the current workout session ID
            return 1; // Example: returning a dummy ID
        }
    }
}
