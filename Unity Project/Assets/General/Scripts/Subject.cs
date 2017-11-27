using System.Collections.Generic;
using UnityEngine;

namespace General.Scripts
{
    public class Subject
    {
        public string Name;
        public Color Colour;
        public readonly List<int> DifficultiesComplete = new List<int>();

        public Subject(string name, Color colour)
        {
            Name = name;
            Colour = colour;
        }
    }
}
