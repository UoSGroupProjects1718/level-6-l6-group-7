using UnityEngine;

public class ScienceSubjectButton : SubjectButtonPress {
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _englishOverlay;
	
	public override void OnPress()
	{
		_mathOverlay.GetComponent<Animator>().SetBool("HideFromScience", true);
		_englishOverlay.GetComponent<Animator>().SetBool("HideFromScience", true);
		InitiateTransitionAnimation();
		StartCoroutine(SceneTransitioner.TransitionTo("Subject Selection", true, 1.5f, 1.5f));
	}
}	
