using System.Collections.Generic;

namespace PumpPad
{
    public class WorkoutPreset
    {
        public string Name { get; set; }
        public List<string> Exercises { get; set; }
        public List<int> Sets { get; set; }
        public List<int> Reps { get; set; }
        public List<string> Instructions { get; set; }

        public static List<WorkoutPreset> GetPresets()
        {
            return new List<WorkoutPreset>
            {
                new WorkoutPreset
                {
                    Name = "Chest Workout",
                    Exercises = new List<string> { "Flat Bench DB Press" },
                    Sets = new List<int> { 4 },
                    Reps = new List<int> { 12, 12, 10, 8 },
                    Instructions = new List<string> { "Perform 4 sets of Flat Bench DB Press with repetitions of 12, 12, 10, 8." }
                }
                // Add more presets here if needed
            };
        }
    }
}
