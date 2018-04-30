using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Scenes.English_Chimp_Challenge.Scripts;
using Scenes.Science_Challenge.Scripts;
using UnityEngine;

namespace General.Scripts
{
	public class GameManager : MonoBehaviour
	{
		private static GameManager _instance;

		public int ChallengesPerSet;
		
		public readonly List<string> EnglishChallengeSceneNames = new List<string>() { "English Chimp Challenge", "English Gorilla Challenge", "English Orangutan Challenge"};
		public readonly List<string> MathChallengeSceneNames = new List<string>() { "Math Chimp Challenge", "Math Gorilla Challenge", "Math Orangutan Challenge"};
		public readonly List<string> ScienceChallengeSceneNames = new List<string>() { "Science Challenge", "Science Challenge", "Science Challenge"};

		public readonly Subject Math = new Subject("Math", new Color32(0, 103, 163, 255));
		public readonly Subject English = new Subject("English", new Color32(229, 69, 59, 255));
		public readonly Subject Science = new Subject("Science", new Color32(75, 191, 107, 255));
		
		public Subject ActiveSubject = null;
		public int? ActiveChallengeDifficulty = null;
		public int? ActiveChallengeNumber = null;
		public bool TutorialRequired = false;

		public bool CompletionHappened;

		public List<ScienceQuestion> CompletedScienceQuestions = new List<ScienceQuestion>();
		public List<EnglishChimpQuestion> CompletedEnglishChimpQuestions = new List<EnglishChimpQuestion>();

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