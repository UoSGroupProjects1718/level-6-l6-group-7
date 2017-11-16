using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	
	public Subject Math = new Subject("Math", 0, 0, new Color32(0, 103, 163, 255));
	public Subject English = new Subject("English", 1, 0, new Color32(229, 69, 53, 255));
	public Subject Science = new Subject("Science", 2, 0, new Color32(75, 191, 107, 255));
	
	public Subject SelectedSubject = null;

	public static GameManager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameManager>();
			}
			return _instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

}
