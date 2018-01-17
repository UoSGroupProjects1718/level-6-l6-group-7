namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class Synonymn
    {
        public string WordToMatch;
        public string MatchingWord;
        public string[] IncorrectAnswers;

        public Synonymn(string wordToMatch, string matchingWord, string[] incorrectAnswers)
        {
            WordToMatch = wordToMatch;
            MatchingWord = matchingWord;
            IncorrectAnswers = incorrectAnswers;
        }
    }
}
