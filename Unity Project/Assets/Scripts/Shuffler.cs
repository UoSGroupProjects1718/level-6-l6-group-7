using System.Collections.Generic;
using UnityEngine;

public class Shuffler
{
	public static void Shuffle<T>(IList<T> list)
	{
		for (var i = list.Count - 1; i > 0; i--)
		{
			var randomIndex = Random.Range(0, i);
			var temporaryItem = list[i];
			list[i] = list[randomIndex];
			list[randomIndex] = temporaryItem;
		}
	}
}
