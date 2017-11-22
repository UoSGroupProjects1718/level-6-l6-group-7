using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectionOverlay : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		GetComponent<Image>().color = new Color(gameManager.SelectedSubject.Colour.r, gameManager.SelectedSubject.Colour.g, gameManager.SelectedSubject.Colour.b, GetComponent<Image>().color.a);
	}
	
}
