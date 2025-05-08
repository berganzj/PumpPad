using SQLite;
using System;

namespace PumpPad.Models
{
    public class WorkoutSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string WorkoutPresetName { get; set; } = string.Empty; // Initialize with default value
        public DateTime Timestamp { get; set; }
        public string? Note { get; set; } // Nullable string note
    }
}
