using UnityEngine;

public class ScienceButtonPressedEvent : SubjectButtonPressedEvent
{
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _englishOverlay;
	
	protected override void PerformTransition()
	{
		_mathOverlay.GetComponent<Animator>().SetBool("HideFromScience", true);
		_englishOverlay.GetComponent<Animator>().SetBool("HideFromScience", true);
	}
}
