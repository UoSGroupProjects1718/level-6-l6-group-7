namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class EnglishChimpQuestion
    {
        public string WordToMatch;
        public string SimilarWord;
        public string[] IncorrectAnswers;

        public EnglishChimpQuestion(string wordToMatch, string similarWord, string[] incorrectAnswers)
        {
            WordToMatch = wordToMatch;
            SimilarWord = similarWord;
            IncorrectAnswers = incorrectAnswers;
        }
    }
}
