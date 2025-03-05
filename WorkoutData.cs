using SQLite;
using System;

namespace PumpPad
{
    public class WorkoutData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ExerciseName { get; set; } = string.Empty; // Initialize with default value
        public string WorkoutPresetName { get; set; } = string.Empty; // Initialize with default value
        public int Sets { get; set; }
        public int Reps { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

