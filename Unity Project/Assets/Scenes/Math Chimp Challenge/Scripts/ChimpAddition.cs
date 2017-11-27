using System;
using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes.Math_Chimp_Challenge.Scripts
{
    public class ChimpAddition : MonoBehaviour
    {
        [SerializeField] private Ladybird _ladybirdLeft;
        [SerializeField] private Ladybird _ladybirdRight;

        private int _correctAnswer;

        [SerializeField] private List<Text> _possibleAnswerSlots = new List<Text>();
        private readonly List<int> _possibleAnswers = new List<int>();

        public IEnumerator CheckAnswer(int value)
        {
            var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            var dropdownSign = GameObject.Find("Dropdown Sign").GetComponent<DropdownSign>();
            var sceneTransitioner = GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>();
            
            if (value == _correctAnswer)
            {
                gameManager.ActiveChallengeNumber++;
                dropdownSign.Dropdown(0.0f, 1.5f, "THAT'S CORRECT! (" + gameManager.ActiveChallengeNumber + "/5)");
            }
            else
            {
                dropdownSign.Dropdown(0.0f, 1.5f, "OOPS, TRY AGAIN (" + gameManager.ActiveChallengeNumber + "/5)");   
            }
            
            while (!dropdownSign.IsRising())
            {
                Debug.Log("NOT RISING");
                yield return new WaitForSeconds(0.25f);
            }
            Debug.Log("RISING");

            if (gameManager.ActiveChallengeNumber == gameManager.ChallengesPerSet)
            {
                sceneTransitioner.TransitionToScene("Subject Selection");
                yield break;
            }
            
            sceneTransitioner.TransitionToScene("Math Chimp Challenge");
        }
    
        private void Awake()
        {
            var ladybirdLeftSpots = Random.Range(2, _ladybirdLeft.GetSpots().Count + 1);
            _ladybirdLeft.SetVisibleSpots(ladybirdLeftSpots);
        
            var ladybirdRightSpots = Random.Range(2, _ladybirdRight.GetSpots().Count + 1);
            _ladybirdRight.SetVisibleSpots(ladybirdRightSpots);

            _correctAnswer = ladybirdLeftSpots + ladybirdRightSpots;
        
            _possibleAnswers.Add(_correctAnswer);
            while (_possibleAnswers.Count != 3)
            {
                int randomAnswer = Random.Range(4, 12);
                bool unique = true;
                foreach (var answer in _possibleAnswers)
                {
                    if (randomAnswer == answer)
                    {
                        unique = false;
                    }
                }
            
                if (unique)
                {
                    _possibleAnswers.Add(randomAnswer);
                }
            }
        
            Shuffler.Shuffle(_possibleAnswers);
            for (var i = 0; i < _possibleAnswers.Count; i++)
            {
                _possibleAnswerSlots[i].text = Convert.ToString(_possibleAnswers[i]);
            }
        
            foreach(var item in _possibleAnswers)
                Debug.Log(item);
        }
    }
}