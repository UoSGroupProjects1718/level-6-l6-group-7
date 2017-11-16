using UnityEngine;

public class ScienceButtonPressedEvent : SubjectButtonPressedEvent
{
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _englishOverlay;
	
	protected override void PerformTransition()
	{
		GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		gameManager.SelectedSubject = gameManager.Science;
		
		_mathOverlay.GetComponent<Animator>().SetBool("HideFromScience", true);
		_englishOverlay.GetComponent<Animator>().SetBool("HideFromScience", true);
	}
}
