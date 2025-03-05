using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpPad
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WorkoutSession>().Wait();
            _database.CreateTableAsync<WorkoutExercise>().Wait();
        }

        public Task<int> SaveWorkoutSessionAsync(WorkoutSession workoutSession)
        {
            return _database.InsertAsync(workoutSession);
        }

        public Task<int> SaveWorkoutExerciseAsync(WorkoutExercise workoutExercise)
        {
            return _database.InsertAsync(workoutExercise);
        }

        public Task<List<WorkoutSession>> GetWorkoutSessionsAsync()
        {
            return _database.Table<WorkoutSession>().ToListAsync();
        }

        public Task<List<WorkoutExercise>> GetWorkoutExercisesAsync(int workoutSessionId)
        {
            return _database.Table<WorkoutExercise>().Where(e => e.WorkoutSessionId == workoutSessionId).ToListAsync();
        }
    }
}

