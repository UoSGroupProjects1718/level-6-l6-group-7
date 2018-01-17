using System.Collections;
using UnityEngine;

namespace Scenes.Sticker_Board.Scripts
{
    public partial class StopMusic : MonoBehaviour {

        private IEnumerator FadeOutTimer()
        {
            GameObject musicObject = GameObject.Find("Music");
            musicObject.GetComponent<MusicPlayer>().StopMusic(2.5f);
            yield return new WaitForSeconds(2.5f);
            Destroy(musicObject);
        }
        
        public void Stop()
        {
            StartCoroutine(FadeOutTimer());
        }

    }
}
