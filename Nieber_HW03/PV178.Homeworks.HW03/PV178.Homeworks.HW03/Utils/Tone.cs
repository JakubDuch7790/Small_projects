﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03.Utils
{
    public class Tone
    {
        public char PositionOnKeyboard { get; set; }
        public string Name { get; set; }
        public int FrequencyOfTone { get; set; }

        public Tone(char positionOnKeyboard, string name, int frequencyOfTone) 
        {
            PositionOnKeyboard = positionOnKeyboard;
            Name = name;
            FrequencyOfTone = frequencyOfTone;
        }
    }
}
