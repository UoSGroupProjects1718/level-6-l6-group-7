using System.Collections;
using System.Linq;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Difficulty_Selection.Scripts
{
    public abstract class DifficultyButtonPressedEvent : ButtonPressedEvent
    {        
        protected void DisableButton()
        {
            GetComponent<Button>().interactable = false;
        }
        
        protected override void ButtonAction()
        {		
            var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            GameObject.Find("Game Manager").GetComponent<MusicPlayer>().StopMusic(3.0f);
            gameManager.ActiveChallengeNumber = 0;
            gameManager.TutorialRequired = true;

            string destinationSceneName = null;
            
            if (gameManager.ActiveSubject == gameManager.English && gameManager.EnglishChallengeSceneNames.Count > 0)
            {
                destinationSceneName = gameManager.EnglishChallengeSceneNames[(int)gameManager.ActiveChallengeDifficulty];
            }
            else if (gameManager.ActiveSubject == gameManager.Math && gameManager.MathChallengeSceneNames.Count > 0)
            {
                destinationSceneName = gameManager.MathChallengeSceneNames[(int)gameManager.ActiveChallengeDifficulty];
            }
            else if (gameManager.ActiveSubject == gameManager.Science && gameManager.ScienceChallengeSceneNames.Count > 0)
            {
                destinationSceneName = gameManager.ScienceChallengeSceneNames[(int)gameManager.ActiveChallengeDifficulty];
            }

            if (destinationSceneName != null)
            {
                StartCoroutine(GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>()
                    .TransitionTo(destinationSceneName));
            }
        }
    }
}