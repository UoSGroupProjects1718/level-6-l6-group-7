using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using Scenes.English_Chimp_Challenge.Scripts;
using Scenes.English_Gorilla_Challenge.Scripts;
using Scenes.English_Orangutan_Challenge.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "Banana")
        {
            collider2D.gameObject.GetComponent<Banana>()._draggable = false;
            collider2D.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            switch (GameManager.Instance.ActiveChallengeDifficulty)
            {
                case Difficulty.Chimp:
                    GameObject.Find("Challenge").GetComponent<EnglishChimpChallenge>()
                        .CheckAnswer(GetComponent<Text>().text);
                    break;
                case Difficulty.Gorilla:
                    GameObject.Find("Challenge").GetComponent<EnglishGorillaChallenge>()
                        .CheckAnswer(GetComponent<Text>().text);
                    break;
                case Difficulty.Orangutan:
                    GameObject.Find("Challenge").GetComponent<EnglishOrangutanChallenge>()
                        .CheckAnswer(GetComponent<Text>().text);
                    break;
            }
        }
    }
    
}
