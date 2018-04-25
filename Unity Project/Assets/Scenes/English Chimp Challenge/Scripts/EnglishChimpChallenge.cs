using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class EnglishChimpChallenge : MonoBehaviour
    {
        [SerializeField] private AudioClip _incorrectAnswerSound;
        [SerializeField] private AudioClip _correctAnswerSound;
        
        [SerializeField] private Text _answerSlot1;
        [SerializeField] private Text _answerSlot2;
        [SerializeField] private Text _answerSlot3;

        [SerializeField] private Image _answerLabel1;
        [SerializeField] private Image _answerLabel2;
        [SerializeField] private Image _answerLabel3;
        
        private EnglishChimpQuestion _activeQuestion;

        private DropdownSign _dropdownSign;

        private IEnumerator ShowWordToMatch(string wordToMatch)
        {
//            // Wait while tutorial is required or is in progress
            while (GameManager.Instance.TutorialRequired)
            {
                yield return new WaitForSeconds(0.1f);
            }
            _dropdownSign.Dropdown(0.0f, float.MaxValue, wordToMatch);
        }

        public IEnumerator EndRound(bool win)
        {
            GetComponent<AudioSource>().PlayOneShot(win ? _correctAnswerSound : _incorrectAnswerSound);
            _answerLabel1.color = _answerSlot1.text == _activeQuestion.SimilarWord ? Colours.GoApeGreen : Colours.GoApeRed;
            _answerLabel2.color = _answerSlot2.text == _activeQuestion.SimilarWord ? Colours.GoApeGreen : Colours.GoApeRed;
            _answerLabel3.color = _answerSlot3.text == _activeQuestion.SimilarWord ? Colours.GoApeGreen : Colours.GoApeRed;

            StartCoroutine(_dropdownSign.GetComponent<DropdownSign>().Override());
            while (!_dropdownSign.IsIdle())
            {
                yield return new WaitForSeconds(0.1f);
            }

            var sceneTransitioner = GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>();
            
            if (win)
            {
                GameManager.Instance.ActiveChallengeNumber++;
                if (GameManager.Instance.ActiveChallengeNumber == GameManager.Instance.ChallengesPerSet)
                {
                    _dropdownSign.Dropdown(0.0f, 1.5f, "WELL DONE!");
                    GameManager.Instance.CompletedEnglishChimpQuestions.Clear();
                }
                else
                {
                    _dropdownSign.Dropdown(0.0f, 1.5f, $"CORRECT! ({GameManager.Instance.ActiveChallengeNumber}/{GameManager.Instance.ChallengesPerSet})");
                    GameManager.Instance.CompletedEnglishChimpQuestions.Add(_activeQuestion);
                }
            }
            else
            {                
                _dropdownSign.Dropdown(0.0f, 1.5f, $"OOPS, TRY AGAIN ({GameManager.Instance.ActiveChallengeNumber}/{GameManager.Instance.ChallengesPerSet})");   
            }
            
            while (!_dropdownSign.IsRising())
            {
                yield return new WaitForSeconds(0.25f);
            }
            
            if (GameManager.Instance.ActiveChallengeNumber == GameManager.Instance.ChallengesPerSet)
            {
                StartCoroutine(FadeDestroyMusic());
                sceneTransitioner.TransitionToScene("Sticker Reward");
                yield break;
            }
            
            sceneTransitioner.TransitionToScene("English Chimp Challenge");
        }
        
        private IEnumerator FadeDestroyMusic()
        {
            GameObject.Find("Soundtrack").GetComponent<MusicPlayer>().StopMusic(2.0f);
            yield return new WaitForSeconds(2.0f);
            GameObject.Destroy(GameObject.Find("Soundtrack"));
        }

        public void CheckAnswer(string answer)
        {
            StartCoroutine(EndRound(answer == _activeQuestion.SimilarWord));
        }
        
        private void Start()
        {
            _dropdownSign = GameObject.Find("Dropdown Sign").GetComponent<DropdownSign>();
            
            if (GameManager.Instance.CompletedEnglishChimpQuestions.Count == EnglishChimpQuestions.Questions.Count)
            {
                GameManager.Instance.CompletedEnglishChimpQuestions.Clear();
            }
		
            do
            {
                var randomQuestion = EnglishChimpQuestions.Questions[Random.Range(0, EnglishChimpQuestions.Questions.Count)];
                if (!GameManager.Instance.CompletedEnglishChimpQuestions.Contains(randomQuestion))
                {
                    _activeQuestion = randomQuestion;
                }
            } while (_activeQuestion == null);

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

            StartCoroutine(ShowWordToMatch(_activeQuestion.WordToMatch));
        }
    
    }
}
