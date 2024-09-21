using UnityEngine;

namespace UI.UIStartWindow
{
    public class UIStartWindowView : UIWindow
    {
        public UIButton StartButton => startButton;
        
        [SerializeField] private UIButton startButton;
        
        public override void Show()
        {
            ShowAction?.Invoke();
        }

        public override void Hide()
        {
            HideAction?.Invoke();
        }
    }
}