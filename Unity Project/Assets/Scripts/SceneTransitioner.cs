using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour {
    
    private const float OpacityMax = 1.0f;
    private const float OpacityMin = 0.0f;
    public const float FadeTimeDefault = 1.0f;
    public const float TimeBeforeFadeDefault = 0.0f;
    
    [Header("[ FADING IN ]")]
    [SerializeField] private bool _fadeIn;
    [SerializeField] private float _fadeInTimeInSeconds;  

    [Header("[ FADING OUT ]")]
    [SerializeField] private bool _fadeOut;
    [SerializeField] private float _fadeOutTimeInSeconds;
    [SerializeField] private float _timeBeforeFadeOut;
    [SerializeField] private bool _transitionsScene;
    [SerializeField] private string _sceneName;

    private Texture _overlayTexture;    
    private Color _overlayColour;    
    private bool _fadeComplete;
    
    /// <summary>
    /// Creates a <c>Texture2D</c> of the specified size and colour.
    /// </summary>
    /// <param name="width">width of the texture in pixels.</param>
    /// <param name="height">height of the texture in pixels.</param>
    /// <param name="colour">colour of the texture.</param>
    /// <returns><c>Texture2D</c> of the specified size and colour.</returns>
    private static Texture2D CreateTexture(int width, int height, Color32 colour)
    {
        var texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        for (var y = 0; y < texture.height; y++)
        {
            for (var x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, colour);
            }
        }
        texture.Apply();
        return texture;
    }

    /// <summary>
    /// Initiates fading and/or scene transitions depending using Unity inspector input.
    /// </summary>
    private void Awake()
    {
        // Create the texture that will overlay the screen during scene transitions.
        _overlayTexture = CreateTexture(1, 1, Color.black);
        
        if (_fadeIn)
        {
            // Scene requires fading in, make the texture fully opaque and fade it in.
            _overlayColour.a = OpacityMax;
            StartCoroutine(FadeOverlayAlpha(OpacityMin, _fadeInTimeInSeconds)); 
        }
        if (_fadeOut)
        {
            // Scene requires fading out, fade it out and transition.
            StartCoroutine(TransitionTo(_transitionsScene ? _sceneName : null, true, _fadeOutTimeInSeconds, _timeBeforeFadeOut)); 
        }
    }

    /// <summary>
    /// Fades the opacity of the overlaying texture to the given value over a period of time.
    /// </summary>
    /// <param name="value">desired opacity value</param>
    /// <param name="time">fade time in seconds</param>
    private IEnumerator FadeOverlayAlpha(float value, float time)
    {
        _fadeComplete = false;
        var alpha = _overlayColour.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            _overlayColour.a = Mathf.Lerp(alpha, value, t);
            yield return null;
        }
        _fadeComplete = true;
    }

    /// <summary>
    /// Fades in the overlaying texture until it is opaque before transitioning to the specified scene.
    /// </summary>
    /// <param name="sceneName">Name of the scene to transition to.</param>
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(TransitionTo(sceneName));
    }

    /// <summary>
    /// Fades in the overlaying texture until it is opaque before transitioning to the specified scene.
    /// </summary>
    /// <param name="sceneName">Name of the scene to transition to.</param>
    /// <param name="fadeOut">Scene will be faded out before transitioning.</param>
    /// <param name="time">fade time in seconds.</param>
    /// <param name="timeBeforeFade">time before fading in seconds.</param>
    /// <returns></returns>
    public IEnumerator TransitionTo(string sceneName, bool fadeOut = true, float time = FadeTimeDefault, float timeBeforeFade = TimeBeforeFadeDefault)
    {
        yield return new WaitForSeconds(timeBeforeFade);
        _overlayColour.a = OpacityMin;
        if (!fadeOut)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            yield break;
        }
        StartCoroutine(FadeOverlayAlpha(OpacityMax, time));
        while (!_fadeComplete)
        {
            yield return new WaitForSeconds(0.1f);
        }
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    /// <summary>
    /// Draws the overlaying texture to the screen.
    /// </summary>
    private void OnGUI()
    {
        GUI.color = _overlayColour;
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), _overlayTexture);
    }
    
}