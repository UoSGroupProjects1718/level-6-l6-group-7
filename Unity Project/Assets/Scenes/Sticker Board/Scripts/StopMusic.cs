using System.Collections;
using UnityEngine;

namespace Scenes.Sticker_Board.Scripts
{
    public partial class StopMusic : MonoBehaviour {

        private IEnumerator FadeOutTimer()
        {
            var musicObject = GameObject.Find("Music");
            if (musicObject != null)
            {
                musicObject.GetComponent<MusicPlayer>().StopMusic(1.5f);

                yield return new WaitForSeconds(1.5f);
                Destroy(musicObject);
            }
        }
        
        public void Stop()
        {
            StartCoroutine(FadeOutTimer());
        }

    }
}
