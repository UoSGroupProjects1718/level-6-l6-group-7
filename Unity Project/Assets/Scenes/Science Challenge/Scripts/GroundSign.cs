using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundSign : MonoBehaviour
{
	private const string AnimState = "State";
	
	private const int AnimStateIdle = 0;
	private const int AnimStateFadeOut = 1;
	private const int AnimStateFadeIn = 2;

	[SerializeField] private Text _headingText;
	[SerializeField] private Text _bodyText;

	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	public void SetText(string headingText, string bodyText)
	{
		_headingText.text = headingText;
		_bodyText.text = bodyText;
	}

	public void SetHeadingText(string headingText)
	{
		_headingText.text = headingText;
	}

	public void SetBodyText(string bodyText)
	{
		_bodyText.text = bodyText;
	}
	
	public void TransitionText(string headingText, string bodyText)
	{
		StartCoroutine(Transition(headingText, bodyText));
	}

	private IEnumerator Transition(string headingText, string bodyText)
	{
		_animator.SetInteger(AnimState, AnimStateFadeOut);
		yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

		_headingText.text = headingText;
		_bodyText.text = bodyText;

		_animator.SetInteger(AnimState, AnimStateFadeIn);
	}
	
}
