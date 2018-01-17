using System.Collections.Generic;

namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class EnglishChimpQuestions
    {
        public static List<Synonymn> Questions = new List<Synonymn>()
        {
            new Synonymn("RUN", "DASH", new string[]{"SWIM", "FLY"}),
            new Synonymn("SING", "CHANT", new string[]{"TALK", "SHOUT"}),
            new Synonymn("PLANT", "HERB", new string[]{"ROCK", "GATE"})
        };
    }
}