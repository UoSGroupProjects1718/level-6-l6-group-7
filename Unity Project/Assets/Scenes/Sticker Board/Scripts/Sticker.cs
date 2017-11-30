using System;
using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes.Sticker_Board.Scripts
{
	public class Sticker : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public string Subject;
		public int Difficulty;
		public bool Dragging;

		[SerializeField] private List<Sprite> _stickerImages;
		
		public void Start()
		{
			var gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
			if (gameManager.ActiveSubject == null || gameManager.ActiveChallengeDifficulty == null ||
			    gameManager.ActiveSubject.DifficultiesComplete.Contains((int)gameManager.ActiveChallengeDifficulty))
			{
				gameObject.SetActive(false);
				return;
			}
			
			Subject = gameManager.ActiveSubject.Name;
			Difficulty = (int) gameManager.ActiveChallengeDifficulty;

			if (Subject == gameManager.Math.Name)
			{
				GetComponent<Image>().sprite = _stickerImages[Difficulty];
			}
			else if (Subject == gameManager.English.Name)
			{
				GetComponent<Image>().sprite = _stickerImages[3 + Difficulty];
			}
			else
			{
				GetComponent<Image>().sprite = _stickerImages[6 + Difficulty];
			}
		}
		
		public void OnBeginDrag(PointerEventData eventData)
		{
			Dragging = true;
			Debug.Log(Dragging);
		}

		public void OnDrag(PointerEventData eventData)
		{
			GetComponent<RectTransform>().position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x,
				GetComponent<RectTransform>().localPosition.y,
				0);
 		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Dragging = false;
			Debug.Log(Dragging);
		}
	}
}
