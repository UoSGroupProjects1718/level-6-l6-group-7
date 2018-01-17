using UnityEngine;
using UnityEngine.UI;

namespace General.Scripts
{
	public class SubjectColourOverlay : MonoBehaviour
	{
		private void Start()
		{
			var gameManager = GameManager.Instance;
			var image = GetComponent<Image>();
			
			image.color = new Color(gameManager.ActiveSubject.Colour.r,
									gameManager.ActiveSubject.Colour.g,
									gameManager.ActiveSubject.Colour.b,
									image.color.a);
		}
	}
}
