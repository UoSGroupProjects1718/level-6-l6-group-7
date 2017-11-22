using UnityEngine;

public abstract class ButtonPressedEvent : MonoBehaviour
{
    [SerializeField] private int _timesPressable;
    private int _timesPressed;

    protected abstract void ButtonAction();

    public void PerformAction()
    {
        if (_timesPressed < _timesPressable)
        {
            ButtonAction();
            _timesPressed++;
        }
    }
}
