using System;
using System.Collections.Generic;

namespace ExerciseTrackerWebAPI.Repositories.Models;

public partial class ExerciseModel
{
    public int ExerciseId { get; set; }

    public string ExerciseName { get; set; } = string.Empty;

    public decimal Weight { get; set; }

    public int? Intensity { get; set; }

    public int Repetitions { get; set; }

    public string? Notes { get; set; }

    public DateTime? Date { get; set; }
}
