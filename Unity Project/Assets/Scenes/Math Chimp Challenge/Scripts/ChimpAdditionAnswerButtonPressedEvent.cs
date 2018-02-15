using System;
using System.Collections.Generic;
using General.Scripts;
using Scenes.Math_Gorilla_Challenge.Scripts;
using Scenes.Math_Orangutan_Challenge.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Math_Chimp_Challenge.Scripts
{
	public class ChimpAdditionAnswerButtonPressedEvent : ButtonPressedEvent
	{
		[SerializeField] private Text _text;
		[SerializeField] private List<Button> _buttonsToDeactivate;

		protected override void ButtonAction()
		{
			if (!GameObject.Find("Dropdown Sign").GetComponent<DropdownSign>().IsIdle())
			{
				TimesPressed--;
				return;
			}

			foreach (var button in _buttonsToDeactivate)
			{
				button.interactable = false;
			}

			Debug.Log("Active Difficulty: " + GameManager.Instance.ActiveChallengeDifficulty);
			switch (GameManager.Instance.ActiveChallengeDifficulty)
			{
				case Difficulty.Chimp:
					StartCoroutine(GameObject.Find("Challenge").GetComponent<ChimpAddition>().CheckAnswer(Convert.ToInt32(_text.text)));
					break;
				case Difficulty.Gorilla:
					StartCoroutine(GameObject.Find("Challenge").GetComponent<MathGorillaChallenge>().CheckAnswer(Convert.ToInt32(_text.text)));
					break;
				case Difficulty.Orangutan:
					StartCoroutine(GameObject.Find("Challenge").GetComponent<MathOrangutanChallenge>().CheckAnswer(Convert.ToInt32(_text.text)));
					break;
			}

		}
	}
}
