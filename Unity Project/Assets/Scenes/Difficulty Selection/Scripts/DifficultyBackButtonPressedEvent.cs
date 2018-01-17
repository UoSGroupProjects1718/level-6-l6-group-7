using General.Scripts;

namespace Scenes.Difficulty_Selection.Scripts
{
    public class DifficultyBackButtonPressedEvent : ButtonPressedEvent {
    
        protected override void ButtonAction()
        {
            GameManager.Instance.ActiveSubject = null;
        }
    
    }
}
