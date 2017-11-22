using UnityEngine;

public class EnglishButtonPressedEvent : SubjectButtonPressedEvent
{
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _scienceOverlay;
	
	private const string SubjectName = "English";
	
	protected override void PerformTransition()
	{
		GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		gameManager.SelectedSubject = gameManager.English;
		
		_mathOverlay.GetComponent<Animator>().SetBool(SubjectName, true);
		_scienceOverlay.GetComponent<Animator>().SetBool(SubjectName, true);
	}
}
