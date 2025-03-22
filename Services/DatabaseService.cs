using PumpPad.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpPad.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WorkoutSession>().Wait();
            _database.CreateTableAsync<WorkoutExercise>().Wait();
            _database.CreateTableAsync<WorkoutSet>().Wait();
        }

        public Task<int> SaveWorkoutSessionAsync(WorkoutSession session)
        {
            return _database.InsertAsync(session);
        }

        public Task<int> SaveWorkoutExerciseAsync(WorkoutExercise exercise)
        {
            return _database.InsertAsync(exercise);
        }

        public Task<int> SaveWorkoutSetAsync(WorkoutSet set)
        {
            return _database.InsertAsync(set);
        }

        public async Task<List<WorkoutExercise>> GetWorkoutExercisesAsync(int workoutSessionId)
        {
            var workoutExercises = await _database.Table<WorkoutExercise>()
                                                   .Where(e => e.WorkoutSessionId == workoutSessionId)
                                                   .ToListAsync();

            foreach (var exercise in workoutExercises)
            {
                exercise.WorkoutSets = await _database.Table<WorkoutSet>()
                                                      .Where(s => s.WorkoutExerciseId == exercise.Id)
                                                      .ToListAsync();
            }

            return workoutExercises;
        }

        public Task<List<WorkoutSession>> GetWorkoutSessionsAsync()
        {
            return _database.Table<WorkoutSession>().ToListAsync();
        }

        public Task ClearWorkoutHistoryAsync()
        {
            return _database.DeleteAllAsync<WorkoutSession>();
        }

        public Task<int> DeleteWorkoutSessionAsync(int sessionId)
        {
            return _database.Table<WorkoutSession>().DeleteAsync(s => s.Id == sessionId);
        }
    }
}

