using System;
using System.Collections.Generic;
using General.Scripts;
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
			
			var chimpAddition =  GameObject.Find("Challenge").GetComponent<ChimpAddition>();
			if (chimpAddition != null)
			{
				StartCoroutine(chimpAddition.CheckAnswer(Convert.ToInt32(_text.text)));
			}
		}
	}
}
