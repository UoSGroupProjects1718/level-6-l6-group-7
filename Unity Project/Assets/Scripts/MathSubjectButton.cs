using UnityEngine;

public class MathSubjectButton : SubjectButtonPress {
    [SerializeField] private GameObject _englishOverlay;
    [SerializeField] private GameObject _scienceOverlay;

    public override void OnPress()
    {
        _englishOverlay.GetComponent<Animator>().SetBool("HideFromMath", true);
        _scienceOverlay.GetComponent<Animator>().SetBool("HideFromMath", true);
        InitiateTransitionAnimation();
        StartCoroutine(SceneTransitioner.TransitionTo("Subject Selection", true, 1.5f, 1.5f));
    }
}
