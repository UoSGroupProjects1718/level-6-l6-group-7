using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SubjectButtonPress : MonoBehaviour {
	[SerializeField] protected Image OverlayImage;
	[SerializeField] protected SceneTransitioner SceneTransitioner;
	[SerializeField] protected List<GameObject> GameObjectsToHide;

	protected void InitiateTransitionAnimation()
	{
		foreach (var gameObject in GameObjectsToHide)
		{
			gameObject.SetActive(false);
		}
		OverlayImage.GetComponent<Transform>().SetAsLastSibling();
		OverlayImage.GetComponent<Animator>().SetBool("Expanding", true);
	}

	public abstract void OnPress();
}
