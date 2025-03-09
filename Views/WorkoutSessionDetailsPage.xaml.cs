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
            // Load session details from the database
            var sessionDetails = await _databaseService.GetWorkoutSessionsAsync();
            var sessionDetail = sessionDetails.FirstOrDefault(s => s.Id == _sessionId);
            // Populate UI with session details
        }

        private async void OnSaveWorkoutClicked(object sender, EventArgs e)
        {
            // Save workout session details
            await _databaseService.SaveWorkoutSessionAsync(new WorkoutSession { Id = _sessionId, /* other details */ });
            await DisplayAlert("Success", "Workout session saved successfully!", "OK");
        }

        private async void OnDeleteWorkoutClicked(object sender, EventArgs e)
        {
            // Delete workout session
            await _databaseService.DeleteWorkoutSessionAsync(_sessionId);
            await DisplayAlert("Success", "Workout session deleted successfully!", "OK");
        }
    }
}