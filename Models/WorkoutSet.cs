using SQLite;

namespace PumpPad.Models
{
    public class WorkoutSet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WorkoutExerciseId { get; set; } // Foreign key to WorkoutExercise
        public int SetIndex { get; set; }
        public int Reps { get; set; }
        public string Weight { get; set; } = string.Empty; // Initialize with default value
    }
}
