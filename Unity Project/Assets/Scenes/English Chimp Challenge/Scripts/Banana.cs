using General.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class Banana : DraggableObject
    {
        private RectTransform _rectTransform;
        public bool _draggable = true;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    
        public override void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(GameObject.Find("Boat").transform);
            if (!_draggable) return;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (!_draggable) return;
            _rectTransform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x,
                _rectTransform.localPosition.y,
                0);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
        }
    
    }
}
