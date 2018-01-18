using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class EnglishChimpChallenge : MonoBehaviour
    {
        [SerializeField] private Text _answerSlot1;
        [SerializeField] private Text _answerSlot2;
        [SerializeField] private Text _answerSlot3;
        
        private EnglishChimpQuestion _activeQuestion;
        
        private void Start()
        {
            // Obtain a random question from those predefined in EnglishChimpQuestions.Questions.
            _activeQuestion = EnglishChimpQuestions.Questions[Random.Range(0, EnglishChimpQuestions.Questions.Count)];  
            
            // Log the chosen question for debugging.
            Debug.Log("Chosen Word: " + _activeQuestion.WordToMatch);
            Debug.Log("Correct Answer: " + _activeQuestion.SimilarWord);
            Debug.Log("Incorect Answers: " + string.Join(", ", _activeQuestion.IncorrectAnswers));
            
            // Obtain all possible answers to the question.
            var possibleAnswers = new List<string>() { _activeQuestion.SimilarWord, _activeQuestion.IncorrectAnswers[0],
                _activeQuestion.IncorrectAnswers[1]};
            
            // Set the answer texts the possible answers (randomly).
            var randomAnswer = Random.Range(0, possibleAnswers.Count);
            _answerSlot1.text = possibleAnswers[randomAnswer];
            possibleAnswers.RemoveAt(randomAnswer);
            
            randomAnswer = Random.Range(0, possibleAnswers.Count);
            _answerSlot2.text = possibleAnswers[randomAnswer];
            possibleAnswers.RemoveAt(randomAnswer);
            
            randomAnswer = Random.Range(0, possibleAnswers.Count);
            _answerSlot3.text = possibleAnswers[randomAnswer];
            possibleAnswers.RemoveAt(randomAnswer);
        }
    
    }
}
