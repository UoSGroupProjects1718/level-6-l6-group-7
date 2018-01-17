using System.Collections;
using General.Scripts;
using UnityEngine;

namespace Scenes.Difficulty_Selection.Scripts
{
    public class GorillaButtonPressedEvent : DifficultyButtonPressedEvent 
    {
        public void Awake()
        {
            var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            if (gameManager.ActiveSubject == gameManager.Math && !gameManager.Math.DifficultiesComplete.Contains(Difficulty.Chimp) ||
                gameManager.ActiveSubject == gameManager.English && !gameManager.English.DifficultiesComplete.Contains(Difficulty.Chimp) ||
                gameManager.ActiveSubject == gameManager.Science && !gameManager.Science.DifficultiesComplete.Contains(Difficulty.Chimp))
            {
                DisableButton();
            }
        }
        
        protected override void ButtonAction()
        {		
            var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.ActiveChallengeDifficulty = Difficulty.Gorilla;;
            base.ButtonAction();
        }
    }
}
