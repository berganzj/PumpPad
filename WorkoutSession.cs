using SQLite;
using System;

namespace PumpPad
{
    public class WorkoutSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string WorkoutPresetName { get; set; } = string.Empty; // Initialize with default value
        public DateTime Timestamp { get; set; }
    }
}
