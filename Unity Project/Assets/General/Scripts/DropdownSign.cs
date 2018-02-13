using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace General.Scripts
{
	public class DropdownSign : MonoBehaviour
	{
		private const int AnimIdleState = 0;
		private const int AnimDroppingState = 1;
		private const int AnimRisingState = 2;

		private const string AnimIdle = "Idle";
		private const string AnimHanging = "Hanging";
		private const string AnimParameter = "State";

		private const float IdleWaitTime = 0.5f;

		public const float DefaultHangTime = 2.5f;
		public const float DefaultTimeBeforeDescent = 0.5f;

		[SerializeField] private float HangTime = DefaultHangTime;

		[SerializeField] private AudioClip _dropDownSound;
		[SerializeField] private AudioClip _riseUpSound;		

		[SerializeField] private bool _dropsDownInitially;
		[SerializeField] private Text _text;
		
		private Animator _animator;

		private Coroutine _display;

		public void Start()
		{
			_animator = GetComponent<Animator>();
			if (_dropsDownInitially && GameManager.Instance.TutorialRequired)
			{
				Dropdown(DefaultTimeBeforeDescent, HangTime);
			}
		}
		
		public void Dropdown(float timeBeforeDescent, float hangTime, string text)
		{
			_text.text = text;	
			_display = StartCoroutine(Display(timeBeforeDescent, hangTime));
		}

		public void Dropdown(float timeBeforeDescent, float hangTime)
		{
			_display = StartCoroutine(Display(timeBeforeDescent, hangTime));
		}
		
		public void Dropdown(float timeBeforeDescent)
		{
			_display = StartCoroutine(Display(timeBeforeDescent, DefaultHangTime));
		}

		public void Dropdown()
		{
			_display = StartCoroutine(Display(DefaultTimeBeforeDescent, DefaultHangTime));
		}

		public bool IsIdle()
		{
			return _animator.GetCurrentAnimatorStateInfo(0).IsName(AnimIdle);
		}

		public bool IsRising()
		{
			return _animator.GetInteger(AnimParameter) == AnimRisingState;
		}

		public IEnumerator Override()
		{
			StopCoroutine(_display);
			if (_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimIdle))
			{
				yield return null;
			}
			
			_animator.SetInteger(AnimParameter, AnimRisingState);
			GetComponent<AudioSource>().PlayOneShot(_riseUpSound);
			
			while(!_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimIdle))
			{
				yield return new WaitForSeconds(IdleWaitTime);
			}
			
			_animator.SetInteger(AnimParameter, AnimIdleState);
			
			GameManager.Instance.TutorialRequired = false;
		}
		
		private IEnumerator Display(float timeBeforeDescent, float hangTime)
		{
			yield return new WaitForSeconds(timeBeforeDescent);

			while(!_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimIdle))
			{
				yield return new WaitForSeconds(IdleWaitTime);
			}
			
			_animator.SetInteger(AnimParameter, AnimDroppingState);
			GetComponent<AudioSource>().PlayOneShot(_dropDownSound);

			while (!_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimHanging))
			{
				yield return new WaitForSeconds(IdleWaitTime);
			}
			
			yield return new WaitForSeconds(hangTime);

			_animator.SetInteger(AnimParameter, AnimRisingState);
			GetComponent<AudioSource>().PlayOneShot(_riseUpSound);
			
			while(!_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimIdle))
			{
				yield return new WaitForSeconds(IdleWaitTime);
			}
			
			_animator.SetInteger(AnimParameter, AnimIdleState);
			
			GameManager.Instance.TutorialRequired = false;
		}
	}
}
