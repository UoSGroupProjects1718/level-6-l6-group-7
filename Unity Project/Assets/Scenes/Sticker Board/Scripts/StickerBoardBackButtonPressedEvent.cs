using General.Scripts;
using UnityEngine;

namespace Scenes.Sticker_Board.Scripts
{
	public class StickerBoardBackButtonPressedEvent : ButtonPressedEvent {

		protected override void ButtonAction()
		{
			var gameManager = GameManager.Instance;
			var sceneTransitioner = GameObject.Find("Scene Transitioner").GetComponent<SceneTransitioner>();
			sceneTransitioner.TransitionToScene(gameManager.ActiveSubject != null ? "Difficulty Selection" : "Subject Selection");
		}
	
	}
}
