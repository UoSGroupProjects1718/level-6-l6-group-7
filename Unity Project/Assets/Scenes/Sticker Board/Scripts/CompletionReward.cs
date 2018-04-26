using System.Collections;
using System.Collections.Generic;
using General.Scripts;
using UnityEngine;

public class CompletionReward : MonoBehaviour
{
    private const string AnimStatespin = "Spin";

    [SerializeField] private AudioClip _sfxSwish;
    [SerializeField] private AudioClip _sfxCheer;

    [SerializeField] private List<Animator> _stickerAnimators;
    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private IEnumerator CompletionEffect()
    {
        var COMPLETION_EFFECT_TOTAL_TIME = 5.0f;
        var TOTAL_STICKERS = _stickerAnimators.Count;
       
        for(var i = 0; i < _stickerAnimators.Count; i++)
        {
            _stickerAnimators[i].Play("Sticker Spin", -1, 0);
            AudioSource.PlayClipAtPoint(_sfxSwish, transform.position, 2.0f);
            if (i == _stickerAnimators.Count - 1)
            {
                AudioSource.PlayClipAtPoint(_sfxCheer, transform.position, 2.0f);
            }
            yield return new WaitForSeconds(0.5f - (0.05f * i));
        }
        
    }
    
    private void Update()
    {
        if (!_gameManager.CompletionHappened && _gameManager.Math.DifficultiesComplete.Count == 3 && _gameManager.English.DifficultiesComplete.Count == 3 &&
            _gameManager.Science.DifficultiesComplete.Count == 3)
        {
            StartCoroutine(CompletionEffect());
            _gameManager.CompletionHappened = true;
        }
    }
    
}
