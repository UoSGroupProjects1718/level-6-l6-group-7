using UnityEngine;

public class MathButtonPressedEvent : SubjectButtonPressedEvent
{
    [SerializeField] private GameObject _englishOverlay;
    [SerializeField] private GameObject _scienceOverlay;

    protected override void PerformTransition()
    {
        _englishOverlay.GetComponent<Animator>().SetBool("HideFromMath", true);
        _scienceOverlay.GetComponent<Animator>().SetBool("HideFromMath", true);
    }
}
