namespace ExerciseTrackerWebAPI.DTOmodels
{
    public class CreateExerciseRequest
    {
        public string ExerciseName { get; set; } = string.Empty;

        public decimal Weight { get; set; }

        public int? Intensity { get; set; }

        public int Repetitions { get; set; }

        public string? Notes { get; set; }

        public DateTime? Date { get; set; }
    }
}
