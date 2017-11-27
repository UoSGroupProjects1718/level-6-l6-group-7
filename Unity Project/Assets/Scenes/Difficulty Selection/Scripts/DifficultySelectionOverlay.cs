using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectionOverlay : MonoBehaviour {

	// Use this for initialization
	void Awake () {		
		GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		GetComponent<Image>().color = new Color(gameManager.ActiveSubject.Colour.r, gameManager.ActiveSubject.Colour.g, gameManager.ActiveSubject.Colour.b, GetComponent<Image>().color.a);
	}
	
}
