using System.Collections;
using UnityEngine;

namespace General.Scripts
{
	public class DropdownSign : MonoBehaviour
	{
		private const int AnimDroppingState = 1;
		private const int AnimRisingState = 2;

		private const string AnimIdle = "Idle";
		private const string AnimHanging = "Hanging";
		private const string AnimParameter = "State";

		private const float IdleWaitTime = 0.5f;

		private const float DefaultHangTime = 2.5f;
		private const float DefaultTimeBeforeDescent = 2.5f;

		[SerializeField] private bool _dropsDownInitially;
		
		private Animator _animator;

		public void Awake()
		{
			_animator = GetComponent<Animator>();
			if (_dropsDownInitially)
			{
				Dropdown();
			}
		}

		public void Dropdown(float timeBeforeDescent, float hangTime)
		{
			StartCoroutine(Display(timeBeforeDescent, hangTime));
		}
		
		public void Dropdown(float timeBeforeDescent)
		{
			StartCoroutine(Display(timeBeforeDescent, DefaultHangTime));
		}

		public void Dropdown()
		{
			StartCoroutine(Display(DefaultTimeBeforeDescent, DefaultHangTime));
		}
	
		private IEnumerator Display(float timeBeforeDescent, float hangTime)
		{
			yield return new WaitForSeconds(timeBeforeDescent);

			while(!_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimIdle))
			{
				yield return new WaitForSeconds(IdleWaitTime);
			}
			
			_animator.SetInteger(AnimParameter, AnimDroppingState);

			while (!_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimHanging))
			{
				yield return new WaitForSeconds(IdleWaitTime);
			}
			
			yield return new WaitForSeconds(hangTime);

			_animator.SetInteger(AnimParameter, AnimRisingState);
		}
	}
}
