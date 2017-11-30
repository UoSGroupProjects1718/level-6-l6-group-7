using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Sticker_Board.Scripts
{
	public class StickerSlot : MonoBehaviour
	{
		[SerializeField] private string _subject;
		[SerializeField] private int _difficulty;
		[SerializeField] private Sprite _sticker;

		private void Start()
		{
			var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();			

			if ((_subject == gameManager.Math.Name && gameManager.Math.DifficultiesComplete.Contains(_difficulty))
				|| (_subject == gameManager.English.Name && gameManager.English.DifficultiesComplete.Contains(_difficulty))
				    || (_subject == gameManager.Science.Name && gameManager.Science.DifficultiesComplete.Contains(_difficulty)))
			{
				GetComponent<Image>().sprite = _sticker;
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			Sticker sticker = null;
			if ((sticker = other.gameObject.GetComponent<Sticker>()) != null)
			{
				if (!sticker.Dragging && sticker.Subject == _subject && sticker.Difficulty == _difficulty)
				{
					var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

					if (gameManager.Math.Name == _subject)
					{
						gameManager.Math.DifficultiesComplete.Add(_difficulty);
					}
					else if (gameManager.English.Name == _subject)
					{
						gameManager.English.DifficultiesComplete.Add(_difficulty);
					}
					else if (gameManager.Science.Name == _subject)
					{
						gameManager.Science.DifficultiesComplete.Add(_difficulty);
					}
					
					GetComponent<Image>().sprite = _sticker;
					Destroy(other.gameObject);
				}
			}
		}
	}
}
