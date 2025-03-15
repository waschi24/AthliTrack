using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthliTrack.models
{
public class Workout
{
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Duration => $"{(int)(End - Start).TotalHours}h {(End - Start).Minutes}min";
    public string Action { get; set; }
    public List<Exercise> Exercises { get; set; } = new();
}

}
