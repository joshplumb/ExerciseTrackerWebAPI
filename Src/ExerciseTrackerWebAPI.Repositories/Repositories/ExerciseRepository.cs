using ExerciseTrackerWebAPI.Repositories.Temp;
using ExerciseTrackerWebAPI.Repositories.Models;
using ExerciseTrackerWebAPI.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExerciseTrackerWebAPI.Repositories.Repositories
{
    public class ExerciseRepository : BaseRepository
    {
        private readonly WorkoutTrackerDatabaseContext _context;
        public ExerciseRepository(WorkoutTrackerDatabaseContext context, IConfiguration configuration) : base(configuration) 
        {
            _context = context;
        }
        public async Task<ExerciseModel> Create(ExerciseModel exercise)
        {
            await _context.AddAsync(exercise);

            await _context.SaveChangesAsync();

            return exercise;
        }
        public async Task<List<ExerciseModel>> GetAll()
        {
            var exercises = await _context.Exercises.ToListAsync();

            return exercises;
        }
        public async Task<ExerciseModel> GetByID(int exerciseID)
        {
            var foundExercise = await _context.Exercises.FindAsync(exerciseID);

            return foundExercise;
        }
        public async Task<ExerciseModel> Update(ExerciseModel exercise)
        {
            _context.Update(exercise);

            await _context.SaveChangesAsync();

            return exercise;
        }
        public async Task<bool> Delete(int exerciseID)
        {
            var foundExercise = await _context.Exercises.FindAsync(exerciseID);

            if(foundExercise is null)
                throw new Exception("ID not found.");

            _context.Exercises.Remove(foundExercise);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
