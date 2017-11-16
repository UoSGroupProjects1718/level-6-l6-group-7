using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectButtonPressedEvent : ButtonPressedEvent
{
	[SerializeField] protected Image SubjectOverlayImage;
	[SerializeField] private string _overlayTransitionAnimationName;
	[SerializeField] private SceneTransitioner _sceneTransitioner;
	[SerializeField] private float _secondsBeforeTransition;
	[SerializeField] private string _destinationSceneName;
	[SerializeField] private List<GameObject> _gameObjectsToDeactivate;

	private static void DeactivateGameObjects(IEnumerable<GameObject> gameObjectsToDeactivate)
	{
		foreach(var gameObject in gameObjectsToDeactivate)
		{
			gameObject.SetActive(false);
		}
	}

	protected virtual void PerformTransition()
	{

	}

	protected override void ButtonAction()
	{
		DeactivateGameObjects(_gameObjectsToDeactivate);
		SubjectOverlayImage.GetComponent<Transform>().SetAsLastSibling();
		SubjectOverlayImage.GetComponent<Animator>().SetBool(_overlayTransitionAnimationName, true);
		PerformTransition();
		StartCoroutine(_sceneTransitioner.TransitionTo(_destinationSceneName, true, SceneTransitioner.FadeTimeDefault, _secondsBeforeTransition));
	}
}
