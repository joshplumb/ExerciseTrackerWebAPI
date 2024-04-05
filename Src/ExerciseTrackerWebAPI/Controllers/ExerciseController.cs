using ExerciseTrackerWebAPI.Controllers;
using ExerciseTrackerWebAPI.DTOmodels;
using ExerciseTrackerWebAPI.Repositories.Models;
using ExerciseTrackerWebAPI.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseRepository _exerciseRepository;

        public ExerciseController(ExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpPost]
        public async Task<ExerciseModel> Create([FromBody] CreateExerciseRequest request)
        {
            var exerciseModel = new ExerciseModel
            {
                ExerciseName = request.ExerciseName,
                Weight = request.Weight,
                Intensity = request.Intensity,
                Repetitions = request.Repetitions,
                Notes = request.Notes,
                Date = request.Date
            };

            var databaseResult = await _exerciseRepository.Create(exerciseModel);

            var response = new ExerciseModel
            {
                ExerciseId = databaseResult.ExerciseId,
                ExerciseName = databaseResult.ExerciseName,
                Weight = databaseResult.Weight,
                Intensity = databaseResult.Intensity,
                Repetitions = databaseResult.Repetitions,
                Notes = databaseResult.Notes,
                Date = databaseResult.Date
            };

            return response;
        }

        [HttpGet]
        public async Task<List<ExerciseModel>> GetAll()
        {
            var result = await _exerciseRepository.GetAll();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ExerciseModel> GetByID([FromRoute] int id)
        {
            var result = await _exerciseRepository.GetByID(id);

            return result;
        }

        [HttpPut]
        public async Task<ExerciseModel> Update([FromBody] ExerciseModel exercise)
        {
            var result = await _exerciseRepository.Update(exercise);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete([FromRoute] int id)
        {
            var result = await _exerciseRepository.Delete(id);

            return true;
        }
    }
}
