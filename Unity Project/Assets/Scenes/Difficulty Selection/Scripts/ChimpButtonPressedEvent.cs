using General.Scripts;
using UnityEngine;

namespace Scenes.Difficulty_Selection.Scripts
{
    public class ChimpButtonPressedEvent : DifficultyButtonPressedEvent 
    {
        protected override void ButtonAction()
        {		
            var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.ActiveChallengeDifficulty = Difficulty.Chimp;
            gameManager.ActiveChallengeNumber = 0;
            gameManager.TutorialRequired = true;
            base.ButtonAction();
        }
    }
}
