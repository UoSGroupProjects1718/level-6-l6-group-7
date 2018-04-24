using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using Scenes.Science_Challenge.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ScienceChallenge : MonoBehaviour
{
	[SerializeField] private List<ScienceQuestion> _chimpQuestions;
	[SerializeField] private List<ScienceQuestion> _gorillaQuestions;
	[SerializeField] private List<ScienceQuestion> _orangutanQuestions;

	[SerializeField] private List<PhotoFrame> _photoFrames;

	[SerializeField] private Text _questionText;
	
	private GameManager _gameManager;
	
	private List<ScienceQuestion> _activeQuestionSet;
	private ScienceQuestion _activeQuestion;
	private PhotoFrame _correctAnswerPhotoFrame;
	
	private void Start()
	{
		_gameManager = GameManager.Instance;
		Setup();
	}

	private void Setup()
	{
		switch (_gameManager.ActiveChallengeDifficulty)
		{
			case Difficulty.Chimp:
				_activeQuestionSet = new List<ScienceQuestion>(_chimpQuestions);
				break;
			case Difficulty.Gorilla:
				_activeQuestionSet = new List<ScienceQuestion>(_gorillaQuestions);
				break;
			case Difficulty.Orangutan:
				_activeQuestionSet = new List<ScienceQuestion>(_orangutanQuestions);
				break;
		}
		
		_activeQuestion = _activeQuestionSet[Random.Range(0, _activeQuestionSet.Count)];

		_questionText.text = _activeQuestion.Question;
        
		_correctAnswerPhotoFrame = _photoFrames[Random.Range(0, _photoFrames.Count)];
		_correctAnswerPhotoFrame.SetPhoto(_activeQuestion.CorrectAnswer);

		var incorectPhotos = new List<Sprite>(_activeQuestion.IncorrectAnswers);
        
		foreach(var photoFrame in _photoFrames)
		{
			if (photoFrame != _correctAnswerPhotoFrame)
			{
				var randomIndex = Random.Range(0, incorectPhotos.Count);
				photoFrame.SetPhoto(incorectPhotos[randomIndex]);
				incorectPhotos.RemoveAt(randomIndex);
			}
		}
	}
	
}
