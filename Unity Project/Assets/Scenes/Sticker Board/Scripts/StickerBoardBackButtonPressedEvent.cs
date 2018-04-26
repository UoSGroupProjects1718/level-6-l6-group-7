using General.Scripts;
using UnityEngine;

namespace Scenes.Sticker_Board.Scripts
{
	public class StickerBoardBackButtonPressedEvent : ButtonPressedEvent {

		protected override void ButtonAction()
		{
			var gameManager = GameManager.Instance;
			var sceneTransitioner = GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>();
			if (gameManager.ActiveSubject == null || gameManager.ActiveSubject.DifficultiesComplete.Count == 3)
			{
				sceneTransitioner.TransitionToScene("Subject Selection");
			}
			else
			{
				sceneTransitioner.TransitionToScene("Difficulty Selection");
			}
		}
	
	}
}
