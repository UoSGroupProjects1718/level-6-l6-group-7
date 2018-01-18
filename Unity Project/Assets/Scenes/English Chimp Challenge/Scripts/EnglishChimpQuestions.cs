using System.Collections.Generic;

namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class EnglishChimpQuestions
    {
        public static List<EnglishChimpQuestion> Questions = new List<EnglishChimpQuestion>()
        {
            new EnglishChimpQuestion("FLY", "SLY", new string[] {"BUG", "FOX"}),
            new EnglishChimpQuestion("BUG", "MUG", new string[] {"DOG", "FISH"}),
            new EnglishChimpQuestion("FOX", "BOX", new string[] {"CAT", "BIKE"}),
            new EnglishChimpQuestion("DOG", "LOG", new string[] {"SUN", "EAT"}),
            new EnglishChimpQuestion("FISH", "DISH", new string[] {"PLATE", "BOY"}),
            new EnglishChimpQuestion("CAT", "HAT", new string[] {"ZOO", "JET"})
        };
    }
}