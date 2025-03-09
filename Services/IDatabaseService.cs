using System.Collections.Generic;
using System.Threading.Tasks;
using PumpPad.Models; // Add this using directive

namespace PumpPad
{
    public interface IDatabaseService
    {
        Task<List<WorkoutExercise>> GetWorkoutExercisesAsync(int workoutSessionId);
    }
}
