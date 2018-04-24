using General.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Science_Challenge.Scripts
{
    public class PhotoFrame : MonoBehaviour
    {
        private static readonly Color ColorCorrect = Colours.GoApeGreen;
        private static readonly Color ColorIncorrect = Colours.GoApeRed;

        [SerializeField] private Button _button;
        [SerializeField] private Image _frame;

        public void SetPhoto(Sprite sprite)
        {
            _button.image.sprite = sprite;
        }

        public void HighlightCorrect()
        {
            _frame.color = ColorCorrect;
        }

        public void HighlightIncorrect()
        {
            _frame.color = ColorIncorrect;
        }

        public void SetInteractable(bool interactable)
        {
            _button.enabled = interactable;
        }
    }
}
