﻿using System.Collections;
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
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = GetComponent<Button>().colors.disabledColor;
            }
            GetComponent<Button>().interactable = false;
        }
        
        protected override void ButtonAction()
        {		
            var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            GameObject.Find("Game Manager").GetComponent<MusicPlayer>().StopMusic(3.0f);
            gameManager.ActiveChallengeNumber = 0;

            string destinationSceneName = null;
            
            if (gameManager.ActiveSubject == gameManager.English && gameManager.EnglishChallengeSceneNames.Count > 0)
            {
                destinationSceneName = gameManager.EnglishChallengeSceneNames[Random.Range(0, gameManager.EnglishChallengeSceneNames.Count)];
            }
            else if (gameManager.ActiveSubject == gameManager.Math && gameManager.MathChallengeSceneNames.Count > 0)
            {
                destinationSceneName = gameManager.MathChallengeSceneNames[Random.Range(0, gameManager.MathChallengeSceneNames.Count)];
            }
            else if (gameManager.ActiveSubject == gameManager.Science && gameManager.ScienceChallengeSceneNames.Count > 0)
            {
                destinationSceneName = gameManager.ScienceChallengeSceneNames[Random.Range(0, gameManager.ScienceChallengeSceneNames.Count)];
            }

            if (destinationSceneName != null)
            {
                StartCoroutine(GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>()
                    .TransitionTo(destinationSceneName));
            }
        }
    }
}