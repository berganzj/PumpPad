using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PumpPad.Models;
using PumpPad.Services;

namespace PumpPad.ViewModels
{
    public class WorkoutSessionDetailsViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;
        private readonly int _workoutSessionId;
        private bool _isReadOnly;

        public ObservableCollection<WorkoutExercise> WorkoutExercises { get; set; }

        public WorkoutSessionDetailsViewModel(int workoutSessionId, bool isReadOnly, IDatabaseService databaseService)
        {
            _workoutSessionId = workoutSessionId;
            _isReadOnly = isReadOnly;
            _databaseService = databaseService;
            WorkoutExercises = new ObservableCollection<WorkoutExercise>();
            LoadWorkoutExercisesCommand = new Command(async () => await LoadWorkoutExercises());
            LoadWorkoutExercisesCommand.Execute(null); // Ensure data is loaded on initialization
        }

        public ICommand LoadWorkoutExercisesCommand { get; }

        private async Task LoadWorkoutExercises()
        {
            var workoutExercises = await _databaseService.GetWorkoutExercisesAsync(_workoutSessionId);
            WorkoutExercises.Clear();
            foreach (var exercise in workoutExercises)
            {
                WorkoutExercises.Add(exercise);
            }
        }
    }
}
