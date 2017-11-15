public class MathSubjectButton : SubjectButtonPress {
    public override void OnPress()
    {
        InitiateTransitionAnimation();
        StartCoroutine(SceneTransitioner.TransitionTo("Subject Selection", true, 1.5f, 1.5f));
    }
}
