﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthliTrack.models
{
    public class Exercise
    {
        public string Name { get; set; }
        public List<ExerciseSet> Sets { get; set; } = new();
    }
}
