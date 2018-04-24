using UnityEngine;

namespace Scenes.Science_Challenge.Scripts
{
    public class PhotoFrameButtonPressedEvent : ButtonPressedEvent
    {
        [SerializeField] private PhotoFrame _photoFrame;
        [SerializeField] private ScienceChallenge _scienceChallenge;
    
        protected override void ButtonAction()
        {
            _scienceChallenge.OnPhotoFrameTapped(_photoFrame);
        }
    }
}
