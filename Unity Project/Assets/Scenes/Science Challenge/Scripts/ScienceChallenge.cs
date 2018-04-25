using System;
using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using Scenes.Science_Challenge.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ScienceChallenge : MonoBehaviour
{
	[SerializeField] private List<ScienceQuestion> _chimpQuestions;
	[SerializeField] private List<ScienceQuestion> _gorillaQuestions;
	[SerializeField] private List<ScienceQuestion> _orangutanQuestions;

	[SerializeField] private List<PhotoFrame> _photoFrames;

	[SerializeField] private GroundSign _groundSign;
	
	[SerializeField] private AudioClip _acCorrectAnswer;
	[SerializeField] private AudioClip _acIncorrectAnswer;
	
	private GameManager _gameManager;
	
	private List<ScienceQuestion> _activeQuestionSet;
	private ScienceQuestion _activeQuestion;
	private PhotoFrame _correctAnswerPhotoFrame;
	
	private void Start()
	{
		_gameManager = GameManager.Instance;
		SetupChallenge();
	}

	private void SetChallengeNumberHeadingText()
	{
		if (_gameManager.ActiveChallengeNumber == null || _gameManager.ActiveChallengeNumber == 0)
		{
			_gameManager.ActiveChallengeNumber = 1;
		}
		
		_groundSign.SetHeadingText($"Challenge {_gameManager.ActiveChallengeNumber} of {_gameManager.ChallengesPerSet}");
	}

	private void SetQuestionText()
	{
		_groundSign.SetBodyText(_activeQuestion.Question);
	}

	private void ObtainRandomQuestion()
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

		if (_gameManager.CompletedScienceQuestions.Count == _activeQuestionSet.Count)
		{
			_gameManager.CompletedScienceQuestions.Clear();
		}
		
		do
		{
			var randomQuestion = _activeQuestionSet[Random.Range(0, _activeQuestionSet.Count)];
			if (!_gameManager.CompletedScienceQuestions.Contains(randomQuestion))
			{
				_activeQuestion = randomQuestion;
			}
		} while (_activeQuestion == null);
	}

	private void SetupPhotoFrames()
	{    
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
	
	private void SetupChallenge()
	{
		ObtainRandomQuestion();
		SetChallengeNumberHeadingText();
		SetQuestionText();
		SetupPhotoFrames();
	}

	private IEnumerator CorrectTransition()
	{
		_groundSign.TransitionText("Correct! Did you know?...", _activeQuestion.Facts[Random.Range(0, _activeQuestion.Facts.Count)]);
		yield return new WaitForSeconds(5.0f);
		if (_gameManager.ActiveChallengeNumber == _gameManager.ChallengesPerSet)
		{
			_gameManager.CompletedScienceQuestions.Clear();
			FindObjectOfType<SceneTransitioner>().TransitionToScene("Sticker Reward");
		}
		else
		{
			_gameManager.ActiveChallengeNumber++;
			FindObjectOfType<SceneTransitioner>().TransitionToScene("Science Challenge");
		}
	}

	private void CorrectAnswer(PhotoFrame photoFrame)
	{
		photoFrame.HighlightCorrect();
		AudioSource.PlayClipAtPoint(_acCorrectAnswer, Vector3.zero);
		_gameManager.CompletedScienceQuestions.Add(_activeQuestion);
		StartCoroutine(CorrectTransition());
	}

	private void IncorrectAnswer(PhotoFrame photoFrame)
	{
		photoFrame.HighlightIncorrect();
		AudioSource.PlayClipAtPoint(_acIncorrectAnswer, Vector3.zero);
		FindObjectOfType<SceneTransitioner>().TransitionToScene("Science Challenge");
	}

	public void OnPhotoFrameTapped(PhotoFrame photoFrame)
	{
		for (var i = 0; i < _photoFrames.Count; i++)
		{
			_photoFrames[i].SetInteractable(false);
		}
		
		if (photoFrame == _correctAnswerPhotoFrame)
		{
			CorrectAnswer(photoFrame);
		}
		else
		{
			IncorrectAnswer(photoFrame);
		}
	}
	
}
