
using UnityEngine;

namespace General.Scripts
{
	public class MenuMusicInitiator : MonoBehaviour {

		private void Start () {
			var gameManager = GameObject.Find("Game Manager");
			if (!gameManager.GetComponent<AudioSource>().isPlaying)
			{
				gameManager.GetComponent<MusicPlayer>().StartMusic(0.0f);
			}	
		}
	
	}
}
