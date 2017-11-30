using UnityEngine;
using UnityEngine.UI;

namespace General.Scripts
{
    public class StickerSelection : MonoBehaviour
    {
        [SerializeField] private Sprite _mathChimpSticker;
        [SerializeField] private Sprite _mathGorillaSticker;
        [SerializeField] private Sprite _mathOrangutanSticker;

        [SerializeField] private Sprite _englishChimpSticker;
        [SerializeField] private Sprite _englishGorillaSticker;
        [SerializeField] private Sprite _englishOrangutanSticker;

        [SerializeField] private Sprite _scienceChimpSticker;
        [SerializeField] private Sprite _scienceGorillaSticker;
        [SerializeField] private Sprite _scienceOrangutanSticker;

        private void Start()
        {
            var gameManager = GameManager.Instance;
            if (gameManager.ActiveSubject == gameManager.Math)
            {
                switch (gameManager.ActiveChallengeDifficulty)
                {
                    case Difficulty.Chimp:
                        GetComponent<Image>().sprite = _mathChimpSticker;
                        break;
                    case Difficulty.Gorilla:
                        GetComponent<Image>().sprite = _mathGorillaSticker;
                        break;
                    case Difficulty.Orangutan:
                        GetComponent<Image>().sprite = _mathOrangutanSticker;
                        break;
                }
            }
            else if (gameManager.ActiveSubject == gameManager.English)
            {
                switch (gameManager.ActiveChallengeDifficulty)
                {
                    case Difficulty.Chimp:
                        GetComponent<Image>().sprite = _englishChimpSticker;
                        break;
                    case Difficulty.Gorilla:
                        GetComponent<Image>().sprite = _englishGorillaSticker;
                        break;
                    case Difficulty.Orangutan:
                        GetComponent<Image>().sprite = _englishOrangutanSticker;
                        break;
                }
            }
            else if (gameManager.ActiveSubject == gameManager.Science)
            {
                switch (gameManager.ActiveChallengeDifficulty)
                {
                    case Difficulty.Chimp:
                        GetComponent<Image>().sprite = _scienceChimpSticker;
                        break;
                    case Difficulty.Gorilla:
                        GetComponent<Image>().sprite = _scienceGorillaSticker;
                        break;
                    case Difficulty.Orangutan:
                        GetComponent<Image>().sprite = _scienceOrangutanSticker;
                        break;
                }
            } 
        }
    }
}
