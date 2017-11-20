using UnityEngine;

public class MathButtonPressedEvent : SubjectButtonPressedEvent
{
    [SerializeField] private GameObject _englishOverlay;
    [SerializeField] private GameObject _scienceOverlay;

    protected override void PerformTransition()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SelectedSubject = gameManager.Math;
        
        _englishOverlay.GetComponent<Animator>().SetBool("HideFromMath", true);
        _scienceOverlay.GetComponent<Animator>().SetBool("HideFromMath", true);
    }
}
