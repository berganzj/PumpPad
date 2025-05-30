using SQLite;

namespace PumpPad.Models
{
    public class WorkoutExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WorkoutSessionId { get; set; }
        public string ExerciseName { get; set; } = string.Empty;

        [Ignore]
        public List<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
    }
}
