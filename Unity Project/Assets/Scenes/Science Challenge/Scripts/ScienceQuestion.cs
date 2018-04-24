using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Science_Challenge.Scripts
{
    [CreateAssetMenu(fileName = "Science Question", menuName = "Science Question")]
    public class ScienceQuestion : ScriptableObject
    {    
        public string Question;
        public List<string> Facts;

        public Sprite CorrectAnswer;
        public List<Sprite> IncorrectAnswers;
    }
}
