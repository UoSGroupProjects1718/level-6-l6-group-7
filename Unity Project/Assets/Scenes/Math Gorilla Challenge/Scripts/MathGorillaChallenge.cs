using System;
using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes.Math_Gorilla_Challenge.Scripts
{
    public class MathGorillaChallenge : MonoBehaviour
    {
        [SerializeField] private AudioClip _incorrectAnswerSound;
        [SerializeField] private AudioClip _correctAnswerSound;
        [SerializeField] private Ladybird _cheetahLeft;
        [SerializeField] private Ladybird _ladybirdRight;

        private int _correctAnswer;

        [SerializeField] private List<Text> _possibleAnswerSlots = new List<Text>();
        private readonly List<int> _possibleAnswers = new List<int>();

        public IEnumerator CheckAnswer(int value)
        {
            var gameManager = GameManager.Instance;
            var dropdownSign = GameObject.Find("Dropdown Sign").GetComponent<DropdownSign>();
            var sceneTransitioner = GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>();
            
            if (value == _correctAnswer)
            {
                GetComponent<AudioSource>().PlayOneShot(_correctAnswerSound);
                gameManager.ActiveChallengeNumber++;
                if (gameManager.ActiveChallengeNumber == gameManager.ChallengesPerSet)
                {
                    dropdownSign.Dropdown(0.0f, 1.5f, "WELL DONE!");
                }
                else
                {
                    dropdownSign.Dropdown(0.0f, 1.5f,
                        $"CORRECT! ({gameManager.ActiveChallengeNumber}/{gameManager.ChallengesPerSet})");
                }
            }
            else
            {                
                GetComponent<AudioSource>().PlayOneShot(_incorrectAnswerSound);
                dropdownSign.Dropdown(0.0f, 1.5f, $"OOPS, TRY AGAIN ({gameManager.ActiveChallengeNumber}/{gameManager.ChallengesPerSet})");   
            }
            
            while (!dropdownSign.IsRising())
            {
                yield return new WaitForSeconds(0.25f);
            }
            
            if (gameManager.ActiveChallengeNumber == gameManager.ChallengesPerSet)
            {
                StartCoroutine(FadeDestroyMusic());
                sceneTransitioner.TransitionToScene("Sticker Reward");
                yield break;
            }
            
            sceneTransitioner.TransitionToScene("Math Gorilla Challenge");
        }

        private IEnumerator FadeDestroyMusic()
        {
            GameObject.Find("Soundtrack").GetComponent<MusicPlayer>().StopMusic(2.0f);
            yield return new WaitForSeconds(2.0f);
            GameObject.Destroy(GameObject.Find("Soundtrack"));
        }

        private IEnumerator EnableTransitions(float pauseTime)
        {
            yield return new WaitForSeconds(pauseTime);
            GameObject.Find("Cheetah Left").GetComponent<Animator>().SetBool("Transition", true);
            GameObject.Find("Ladybird Right").GetComponent<Animator>().SetBool("Transition", true);
        }
    
        private void Awake()
        {
            StartCoroutine(EnableTransitions(GameObject.Find("Game Manager").GetComponent<GameManager>().TutorialRequired ? 4.5f : 0.0f));            
            
            var ladybirdLeftSpots = Random.Range(7, _cheetahLeft.GetSpots().Count + 1);
            _cheetahLeft.SetVisibleSpots(ladybirdLeftSpots);
        
            var ladybirdRightSpots = Random.Range(2, _ladybirdRight.GetSpots().Count + 1);
            _ladybirdRight.SetVisibleSpots(ladybirdRightSpots);

            _correctAnswer = ladybirdLeftSpots - ladybirdRightSpots;
        
            _possibleAnswers.Add(_correctAnswer);
            while (_possibleAnswers.Count != 3)
            {
                int randomAnswer = Random.Range(_correctAnswer - 5, _correctAnswer + 5);
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
        }
    }
}