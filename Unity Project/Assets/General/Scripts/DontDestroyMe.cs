using UnityEngine;
using System.Linq;

namespace General.Scripts
{
	public class DontDestroyMe : MonoBehaviour {

		void Awake()
		{
			DontDestroyOnLoad(gameObject);
			var objectsWithName = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == gameObject.name);
			if (objectsWithName.Count() > 1)
			{
				Destroy(gameObject);
			}
		}
	
	}
}
