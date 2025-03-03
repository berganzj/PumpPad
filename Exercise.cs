using System.Collections.Generic;

namespace PumpPad
{
    public class Exercise
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public List<int> Reps { get; set; }
        public string Instruction { get; set; }

        public Exercise(string name, int sets, List<int> reps, string instruction)
        {
            Name = name;
            Sets = sets;
            Reps = reps;
            Instruction = instruction;
        }
    }
}
