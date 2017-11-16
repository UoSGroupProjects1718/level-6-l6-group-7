using UnityEngine;

public class EnglishButtonPressedEvent : SubjectButtonPressedEvent
{
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _scienceOverlay;
	
	protected override void PerformTransition()
	{
		_mathOverlay.GetComponent<Animator>().SetBool("HideFromEnglish", true);
		_scienceOverlay.GetComponent<Animator>().SetBool("HideFromEnglish", true);
	}
}
