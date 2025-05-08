using System.Collections.Generic;

namespace PumpPad.Models
{
    public class WorkoutPreset
    {
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public List<Exercise> Exercises { get; set; } = new List<Exercise>(); // Initialize with default value

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
                        new Exercise("Incline DB Press", 3, new List<int> { 8210, 8210, 12}, "Heavy sets 1 and 2, lighter weight 3"),
                        new Exercise("Incline DB Fyle", 3, new List<int> { 12, 12, 12}, "Same weight"),
                        new Exercise("Pec Dec Fyle", 3, new List<int> { 12, 12, 12}, "Same weight")
                    }
                },
                new WorkoutPreset
                {
                    Name = "Tricep Workout",
                    Exercises = new List<Exercise>
                    {
                        new Exercise("French Press", 4, new List<int> { 12, 12, 10, 8 }, "Pyramid up in weight"),
                        new Exercise("DB Kickback", 2, new List<int> { 15, 15}, "Same weight"),
                        new Exercise("Reverse Grip Pull Down", 2, new List<int> { 15, 15}, "Same weight")
                    }
                },
                new WorkoutPreset
                {
                    Name = "Bicep Workout",
                    Exercises = new List<Exercise>
                    {
                        new Exercise("Standing EZ-Bar Curl", 4, new List<int> { 12, 12, 10, 8 }, "Pyramid up in weight"),
                        new Exercise("Seated DB Alt. Curl", 3, new List<int> { 8210, 8210,12}, "Heavy weight 1 and 2, lighter weight 3"),
                        new Exercise("DB Unilateral Preacher Curl", 2, new List<int> { 15, 15}, "Moderately heavy weight, go to failure")
                    }
                },
                new WorkoutPreset
                {
                    Name = "Shoulder Workout",
                    Exercises = new List<Exercise>
                    {
                        new Exercise("Seated Smith Machine Press", 4, new List<int> { 12, 12, 10, 8 }, "Pyramid up in weight"),
                        new Exercise("Arnold Press", 3, new List<int> { 8210, 8210,12}, "Heavy weight 1 and 2, lighter weight 3"),
                        new Exercise("Overhead DB Lateral Raise", 3, new List<int> { 10, 10, 12}, "Same weight 2 sets, lighter weight 3")
                    }
                }
                // Add more presets here if needed
            };
        }
    }
}

