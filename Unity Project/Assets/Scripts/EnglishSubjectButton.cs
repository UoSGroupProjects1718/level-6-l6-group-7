using UnityEngine;

public class EnglishSubjectButton : SubjectButtonPress {
	[SerializeField] private GameObject _mathOverlay;
	[SerializeField] private GameObject _scienceOverlay;
	
	public override void OnPress()
	{
		_mathOverlay.GetComponent<Animator>().SetBool("HideFromEnglish", true);
		_scienceOverlay.GetComponent<Animator>().SetBool("HideFromEnglish", true);
		InitiateTransitionAnimation();
		StartCoroutine(SceneTransitioner.TransitionTo("Subject Selection", true, 1.5f, 1.5f));
	}
}
