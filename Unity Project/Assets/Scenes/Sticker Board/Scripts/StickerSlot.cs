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

		private GameManager _gameManager;

		private void Start()
		{
			_gameManager = GameManager.Instance;
			if (_gameManager.ActiveSubject.Name == _subject && _gameManager.ActiveSubject.DifficultiesComplete.Contains(_difficulty))
				GetComponent<Image>().sprite = _sticker;
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			var draggableSticker = collision.GetComponent<DraggableSticker>();
			if (draggableSticker == null || draggableSticker.IsBeingDragged() || draggableSticker.Difficulty != _difficulty || draggableSticker.Subject.Name != _subject)
				return;
			// TODO: This may need to use gameManager instead of draggableSticker (possibly different references).
			draggableSticker.Subject.DifficultiesComplete.Add(_difficulty);
			GetComponent<Image>().sprite = _sticker;
			Destroy(collision.gameObject);
			GameObject.Find("Back Button").GetComponent<Button>().interactable = true;
		}
	}
}