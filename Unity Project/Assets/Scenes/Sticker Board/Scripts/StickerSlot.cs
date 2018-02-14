using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Sticker_Board.Scripts
{
	public class StickerSlot : MonoBehaviour
	{
		[SerializeField] private AudioClip _fitSlotSound;
		[SerializeField] private string _subject;
		[SerializeField] private int _difficulty;
		[SerializeField] private Sprite _sticker;

		private GameManager _gameManager;

		private void Start()
		{
			_gameManager = GameManager.Instance;
			if (_subject == "Math" && _gameManager.Math.DifficultiesComplete.Contains(_difficulty))
			{
				GetComponent<Image>().sprite = _sticker;
			}
			else if (_subject == "English" && _gameManager.English.DifficultiesComplete.Contains(_difficulty))
			{
				GetComponent<Image>().sprite = _sticker;
			}
			else if (_subject == "Science" && _gameManager.Science.DifficultiesComplete.Contains(_difficulty))
			{
				GetComponent<Image>().sprite = _sticker;
			}
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			var draggableSticker = collision.GetComponent<DraggableSticker>();
			if (draggableSticker == null || draggableSticker.IsBeingDragged() || draggableSticker.Difficulty != _difficulty || draggableSticker.Subject.Name != _subject)
				return;
			if (draggableSticker.Subject.Name == "Math")
				_gameManager.Math.DifficultiesComplete.Add(_difficulty);
			else if (draggableSticker.Subject.Name == "English")
			{
				_gameManager.English.DifficultiesComplete.Add(_difficulty);
			}
			else if (draggableSticker.Subject.Name == "Science")
			{
				_gameManager.Science.DifficultiesComplete.Add(_difficulty);
			}
			GetComponent<Image>().sprite = _sticker;
			Destroy(collision.gameObject);
			GetComponent<AudioSource>().PlayOneShot(_fitSlotSound);
			GameObject.Find("Back Button").GetComponent<Button>().interactable = true;
		}
	}
}