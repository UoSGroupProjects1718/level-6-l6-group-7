using General.Scripts;
using UnityEngine;

public class ScienceButtonPressedEvent : SubjectButtonPressedEvent
{
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _englishOverlay;

	private const string SubjectName = "Science";
	
	protected override void PerformTransition()
	{
		var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		gameManager.ActiveSubject = gameManager.Science;

		_mathOverlay.GetComponent<Animator>().SetBool(SubjectName, true);
		_englishOverlay.GetComponent<Animator>().SetBool(SubjectName, true);
	}
}
