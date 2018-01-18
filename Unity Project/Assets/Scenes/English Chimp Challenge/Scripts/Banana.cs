using General.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.English_Chimp_Challenge.Scripts
{
    public class Banana : DraggableObject
    {
        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            Debug.Log("BANANA");
        }
    
        public override void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("Begin Drag");
        }

        public override void OnDrag(PointerEventData eventData)
        {
            Debug.Log("On Drag");
            _rectTransform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x,
                _rectTransform.localPosition.y,
                0);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("End Drag");
        }
    
    }
}
