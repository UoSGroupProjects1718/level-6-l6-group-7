using General.Scripts;
using UnityEngine;

public class MathButtonPressedEvent : SubjectButtonPressedEvent
{
    [SerializeField] private GameObject _englishOverlay;
    [SerializeField] private GameObject _scienceOverlay;
    
    protected override void PerformTransition()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.ActiveSubject = gameManager.Math;
        
        _englishOverlay.GetComponent<Animator>().SetBool(SubjectName, true);
        _scienceOverlay.GetComponent<Animator>().SetBool(SubjectName, true);
    }
}
