using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

namespace General.Scripts
{
	public class GameManager : MonoBehaviour
	{
		private static GameManager _instance;

		public int ChallengesPerSet = 2;
		
		public readonly List<string> EnglishChallengeSceneNames = new List<string>();
		public readonly List<string> MathChallengeSceneNames = new List<string>() { "Math Chimp Challenge"};
		public readonly List<string> ScienceChallengeSceneNames = new List<string>();

		public readonly Subject Math = new Subject("Math", new Color32(0, 103, 163, 255));
		public readonly Subject English = new Subject("English", new Color32(229, 69, 59, 255));
		public readonly Subject Science = new Subject("Science", new Color32(75, 191, 107, 255));
		
		public Subject ActiveSubject = null;
		public int? ActiveChallengeDifficulty = null;
		public int? ActiveChallengeNumber = null;
		public bool TutorialRequired = false;
		
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
}
