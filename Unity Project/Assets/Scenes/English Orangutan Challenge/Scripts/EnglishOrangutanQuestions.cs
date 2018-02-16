using System.Collections.Generic;
using Scenes.English_Chimp_Challenge.Scripts;

namespace Scenes.English_Orangutan_Challenge.Scripts
{
	public class EnglishOrangutanQuestions
	{
		public static List<EnglishChimpQuestion> Questions = new List<EnglishChimpQuestion>()
		{
			new EnglishChimpQuestion("CRY", "WEEP", new string[] {"SEAT", "DRY"}),
			new EnglishChimpQuestion("WET", "DAMP", new string[] {"LAMP", "WASH"}),
			new EnglishChimpQuestion("SEAT", "CHAIR", new string[] {"SAT", "MEAT"}),
			new EnglishChimpQuestion("RUN", "SPRINT", new string[] {"FUN", "STREET"}),
			new EnglishChimpQuestion("SHOUT", "YELL", new string[] {"FELL", "NOISE"}),
			new EnglishChimpQuestion("HAPPY", "JOLLY", new string[] {"CLAP", "SAD"}),
			new EnglishChimpQuestion("WALK", "STEP", new string[] {"TALK", "STOP"}),
			new EnglishChimpQuestion("FOREST", "WOOD", new string[] {"FLOOR", "TEST"}),
			new EnglishChimpQuestion("ROPE", "STRING", new string[] {"COPE", "SING"}),
			new EnglishChimpQuestion("CHIMP", "APE", new string[] {"LIMP", "TIGER"})
		};
	}
}