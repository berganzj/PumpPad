using SQLite;

namespace PumpPad
{
    public class WorkoutExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WorkoutSessionId { get; set; } // Foreign key to WorkoutSession
        public string ExerciseName { get; set; } = string.Empty; // Initialize with default value
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
