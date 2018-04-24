using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Science_Challenge.Scripts
{
    public class PhotoFrame : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void SetPhoto(Sprite sprite)
        {
            _button.image.sprite = sprite;
        }
    }
}
