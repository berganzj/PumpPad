using System.Collections.Generic;

namespace PumpPad
{
    public class WorkoutPreset
    {
        public string Name { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public static List<WorkoutPreset> GetPresets()
        {
            return new List<WorkoutPreset>
            {
                new WorkoutPreset
                {
                    Name = "Chest Workout",
                    Exercises = new List<Exercise>
                    {
                        new Exercise("Flat Bench DB Press", 4, new List<int> { 12, 12, 10, 8 }, "Pyramid up in weight"),
                        new Exercise("Incline DB Press", 3, new List<int> { 10, 10, 12}, "Heavy sets 1 and 2, lighter weight 3"),
                        new Exercise("Incline DB Fyle", 3, new List<int> { 12, 12, 12}, "Same weight"),
                        new Exercise("Pec Dec Fyle", 3, new List<int> { 12, 12, 12}, "Same weight"),
                    }
                },
                new WorkoutPreset
                {
                    Name = "Tricep Workout",
                    Exercises = new List<Exercise>
                    {
                        new Exercise("French Press", 4, new List<int> { 12, 12, 10, 8 }, "Pyramid up in weight"),
                        new Exercise("DB Kickback", 2, new List<int> { 15, 15}, "Same weight"),
                        new Exercise("Reverse Grip Pull Down", 2, new List<int> { 15, 15}, "Same weight"),
                    }
                }
                // Add more presets here if needed
            };
        }
    }
}

