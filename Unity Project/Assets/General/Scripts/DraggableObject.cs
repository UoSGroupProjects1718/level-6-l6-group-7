using UnityEngine;
using UnityEngine.EventSystems;

namespace General.Scripts
{
	public abstract class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public abstract void OnBeginDrag(PointerEventData eventData);

		public abstract void OnDrag(PointerEventData eventData);

		public abstract void OnEndDrag(PointerEventData eventData);
	}
}
