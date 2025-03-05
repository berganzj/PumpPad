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
        _workoutSessions = await _databaseService.GetWorkoutSessionsAsync();
        WorkoutsListView.ItemsSource = _workoutSessions;
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
            await Navigation.PushAsync(new WorkoutSessionDetailsPage(selectedWorkoutSession.Id));
        }
    }
}
