using UnityEngine;

public class Draggable : MonoBehaviour
{
	private void Update()
	{
		if (Input.touchCount > 0)
		{
			GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
		}
	}
}
