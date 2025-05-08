using PumpPad.Models;
using PumpPad.Services;

namespace PumpPad;

public partial class ReviewWorkoutsPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private List<WorkoutSession> _workoutSessions = new List<WorkoutSession>(); // Initialize with default value

    public ReviewWorkoutsPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService(FileAccessHelper.GetLocalFilePath("workouts.db3"));
        LoadWorkoutSessions();
    }

    private async void LoadWorkoutSessions()
    {
        try
        {
            _workoutSessions = await _databaseService.GetWorkoutSessionsAsync();
            WorkoutsListView.ItemsSource = _workoutSessions;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading workout sessions: {ex.Message}");
        }
    }

    private void OnSortByWorkoutPresetNameClicked(object sender, EventArgs e)
    {
        var sortedWorkoutSessions = _workoutSessions.OrderBy(w => w.WorkoutPresetName).ToList();
        WorkoutsListView.ItemsSource = sortedWorkoutSessions;
    }

    private void OnSortByDateClicked(object sender, EventArgs e)
    {
        var sortedWorkoutSessions = _workoutSessions.OrderBy(w => w.Timestamp).ToList();
        WorkoutsListView.ItemsSource = sortedWorkoutSessions;
    }

    private async void OnWorkoutSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is WorkoutSession selectedWorkoutSession)
        {
            await Navigation.PushAsync(new ViewWorkoutDetailsPage(selectedWorkoutSession.Id, isReadOnly: true));
        }
    }

    private async void OnClearWorkoutHistoryClicked(object sender, EventArgs e)
    {
        await _databaseService.ClearWorkoutHistoryAsync();
        LoadWorkoutSessions();
    }
}
