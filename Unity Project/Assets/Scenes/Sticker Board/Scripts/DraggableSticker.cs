using General.Scripts;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes.Sticker_Board.Scripts
{
    public class DraggableSticker : DraggableObject
    {
        [SerializeField] private AudioClip _pickupSound;
        
        public Subject Subject;
        public int? Difficulty;
        
        private bool _beingDragged;
        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();

            var gameManager = GameManager.Instance;
            if (gameManager.ActiveSubject == null ||
                gameManager.ActiveSubject.DifficultiesComplete.Contains((int) gameManager.ActiveChallengeDifficulty))
            {
                GameObject.Find("Back Button").GetComponent<Button>().interactable = true;
                gameObject.SetActive(false);
            }

            Subject = gameManager.ActiveSubject;
            Difficulty = gameManager.ActiveChallengeDifficulty;
        }
        
        public override void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<AudioSource>().PlayOneShot(_pickupSound);
            _beingDragged = true;
        }

        public override void OnDrag(PointerEventData eventData)
        {
            _rectTransform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x,
                                                       _rectTransform.localPosition.y,
                                                        0);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            _beingDragged = false;
        }

        public bool IsBeingDragged()
        {
            return _beingDragged;
        }
    }
}
