using System.Collections.Generic;

namespace PumpPad.Models
{
    public class Exercise
    {
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public int Sets { get; set; }
        public List<int> Reps { get; set; } = new List<int>(); // Initialize with default value
        public string Instruction { get; set; } = string.Empty; // Initialize with default value

        public Exercise(string name, int sets, List<int> reps, string instruction)
        {
            Name = name;
            Sets = sets;
            Reps = reps;
            Instruction = instruction;
        }
    }
}
